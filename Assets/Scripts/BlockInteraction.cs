using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static Block;
using UnityStandardAssets.Characters.FirstPerson;

public class BlockInteraction : NetworkBehaviour
{

    public GameObject cam;
    //public BlockType selectedBlockType;
    public Toolbar toolbar;
    public FirstPersonController fpsController;

    // Update is called once per frame

    [ClientRpc]
    void RpcHitBlock(Block t)
    {
        t.HitBlock();
    }
    void Update()
    {
        if (!isLocalPlayer) { return; }
        if (fpsController.inUI)
            return;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //for mouse clicking
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            //if ( Physics.Raycast (ray,out hit,10)) 
            //{

            //for cross hairs
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10))
            {
                Chunk hitc;
                if (!World.chunks.TryGetValue(hit.collider.gameObject.name, out hitc)) return;

                Vector3 hitBlock;
                if (Input.GetMouseButtonDown(0))
                {
                    hitBlock = hit.point - hit.normal / 2.0f;

                }
                else
                    hitBlock = hit.point + hit.normal / 2.0f;

                int x = (int)(Mathf.Round(hitBlock.x) - hit.collider.gameObject.transform.position.x);
                int y = (int)(Mathf.Round(hitBlock.y) - hit.collider.gameObject.transform.position.y);
                int z = (int)(Mathf.Round(hitBlock.z) - hit.collider.gameObject.transform.position.z);

                bool update = false;
                if (Input.GetMouseButtonDown(0))
                {
                    update = hitc.chunkData[x, y, z].HitBlock();
                    //Debug.Log("OUR TYPE IS : " + hitc.chunkData[x, y, z].GetType());
                    RpcHitBlock(hitc.chunkData[x, y, z]);

                    
                }
                else
                {
                    if (toolbar.slots[toolbar.slotIndex].HasItem)
                    {
                        update = hitc.chunkData[x, y, z].BuildBlock(toolbar.slots[toolbar.slotIndex].itemSlot.stack.item.blockType);
                        toolbar.slots[toolbar.slotIndex].itemSlot.Take(1);
                    }
                    
                }

                if (update)
                {
                    hitc.changed = true;
                    List<string> updates = new List<string>();
                    float thisChunkx = hitc.chunk.transform.position.x;
                    float thisChunky = hitc.chunk.transform.position.y;
                    float thisChunkz = hitc.chunk.transform.position.z;

                    //updates.Add(hit.collider.gameObject.name);

                    //update neighbours?
                    if (x == 0)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx - World.chunkSize, thisChunky, thisChunkz)));
                    if (x == World.chunkSize - 1)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx + World.chunkSize, thisChunky, thisChunkz)));
                    if (y == 0)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky - World.chunkSize, thisChunkz)));
                    if (y == World.chunkSize - 1)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky + World.chunkSize, thisChunkz)));
                    if (z == 0)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky, thisChunkz - World.chunkSize)));
                    if (z == World.chunkSize - 1)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky, thisChunkz + World.chunkSize)));

                    foreach (string cname in updates)
                    {
                        Chunk c;
                        if (World.chunks.TryGetValue(cname, out c))
                        {
                            c.Redraw();
                        }
                    }
                }
            }
        }
    }
}

