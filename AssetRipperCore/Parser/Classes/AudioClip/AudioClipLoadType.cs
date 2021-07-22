﻿namespace AssetRipper.Parser.Classes.AudioClip
{
	public enum AudioClipLoadType
	{
		DecompressOnLoad	= 0,
		CompressedInMemory	= 1,
		/// <summary>
		/// StreamFromDisc previously
		/// </summary>
		Streaming			= 2,
	}
}