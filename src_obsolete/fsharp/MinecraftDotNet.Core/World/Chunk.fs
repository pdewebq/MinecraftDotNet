module MinecraftDotNet.Core.World.Chunk

open System.Collections.Generic
open MinecraftDotNet.Core
open MinecraftDotNet.Core.Math.Linear


let size = Vector3.create Chunk.Width Chunk.Height Chunk.Depth

//let createFilled block =
//    { BlockInfos = Array3D.create Chunk.Width Chunk.Height Chunk.Depth block.BlockInfo
//      BlockMetas = Dictionary<BlockCoords, Meta>() }

let getMeta chunk coords =
    match chunk.BlockMetas.TryGetValue(coords) with
    | (false, _) -> Meta.Empty
    | (true, m) -> m

let getBlockInfo chunk (coords: BlockCoords) =
    chunk.BlockInfos.[coords.X, coords.Y, coords.Z]

let getBlock chunk coords =
    { BlockInfo = getBlockInfo chunk coords
      Meta = getMeta chunk coords }

let setBlockInfo chunk (coords: BlockCoords) blockInfo =
    chunk.BlockInfos.[coords.X, coords.Y, coords.Z] <- blockInfo
    chunk

let setMeta chunk coords meta =
    if meta <> Meta.Empty then
        chunk.BlockMetas.[coords] <- meta
    chunk

let setBlock chunk (coords: BlockCoords) block =
    let chunk = setBlockInfo chunk coords block.BlockInfo
    let chunk = setMeta chunk coords block.Meta
    chunk

let mutatei mapping chunk =
    let getBlock = getBlock chunk
    let setBlock = setBlock chunk
    for x in 0 .. size.X - 1 do
        for y in 0 .. size.Y - 1 do
            for z in 0 .. size.Z - 1 do
                let coords = Vector3.create x y z
                mapping coords (getBlock coords) |> setBlock coords |> ignore
    chunk

let mutate mapping = mutatei (fun _ -> mapping)

let toBlocks (chunk: Chunk) =
    let getBlock = getBlock chunk
    seq {
        for x in 0 .. Chunk.Width-1 do
        for y in 0 .. Chunk.Height-1 do
        for z in 0 .. Chunk.Depth-1 do
            yield getBlock { X = x; Y = y; Z = z }
    }

let mapi mapping chunk =
    { chunk with
        BlockInfos = Array3D.mapi (fun x y z -> mapping { X = x; Y = y; Z = z }) chunk.BlockInfos }

let map mapping = mapi (fun _ -> mapping)

let iteri action chunk =
    Array3D.iteri action chunk.BlockInfos

let iter action = iteri (fun _ _ _ -> action)


type Chunk with
    member this.Item // Indexer
        with get coords = getBlock this coords
        and  set coords block = setBlock this coords block |> ignore