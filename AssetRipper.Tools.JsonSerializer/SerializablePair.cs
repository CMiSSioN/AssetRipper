﻿using AssetRipper.IO.Endian;
using AssetRipper.IO.Files.SerializedFiles.Parser.TypeTrees;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace AssetRipper.Tools.JsonSerializer;

public sealed class SerializablePair : SerializableEntry
{
	public SerializableEntry First { get; }
	public SerializableEntry Second { get; }

	public SerializablePair(SerializableEntry first, SerializableEntry second)
	{
		First = first;
		Second = second;
	}

	public override JsonNode Read(EndianReader reader)
	{
		JsonObject result = new()
		{
			{ "first", First.Read(reader) },
			{ "second", Second.Read(reader) }
		};
		MaybeAlign(reader);
		return result;
	}

	public static new SerializablePair FromTypeTreeNodes(List<TypeTreeNode> list, ref int index)
	{
		index++;
		ThrowIfIncorrectName(list[index], "first");
		index++;
		SerializableEntry first = SerializableEntry.FromTypeTreeNodes(list, ref index);
		ThrowIfIncorrectName(list[index], "second");
		index++;
		SerializableEntry second = SerializableEntry.FromTypeTreeNodes(list, ref index);
		return new SerializablePair(first, second);
	}
}
