using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;

[BurstCompile]
public struct BuildBlockJob : IJob
{
    public Block.BlockType blockType;
    public Chunk owner;
    public int blockHealthMax;
    public Block block;

    public void Execute()
    {
        if (blockType == Block.BlockType.WATER)
        {
            owner.mb.StartCoroutine(owner.mb.Flow(block,
                                        blockType,
                                        blockHealthMax, 15));
        }
        else if (blockType == Block.BlockType.SAND)
        {
            owner.mb.StartCoroutine(owner.mb.Drop(block,
                                        blockType,
                                        20));
        }
        else
        {
            block.SetType(blockType);
            owner.Redraw();
        }
    }
}
