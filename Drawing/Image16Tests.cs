using System;
using Free.Core.Drawing;
using NUnit.Framework;

namespace Free.Core.Tests.Drawing
{
	[TestFixture]
	public class Image16Tests
	{
		[Test]
		public static void Image16ConstructorTest()
		{
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(1, img.Bits.Length);
				Assert.NotNull(img.Bits[0]);
				Assert.AreEqual(1234 * 345 * 4, img.Bits[0].Length);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);

				bool ok = true;
				var bits = img.Bits[0];
				for (int i = 0; i < bits.Length;)
				{
					if (bits[i++] != 0x1111) { ok = false; break; }
					if (bits[i++] != 0x2222) { ok = false; break; }
					if (bits[i++] != 0x3333) { ok = false; break; }
					if (bits[i++] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(1, img.Bits.Length);
				Assert.NotNull(img.Bits[0]);
				Assert.AreEqual(1234 * 345 * 4, img.Bits[0].Length);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);

				bool ok = true;
				var bits = img.Bits[0];
				for (int i = 0; i < bits.Length;)
				{
					if (bits[i++] != 0x1111) { ok = false; break; }
					if (bits[i++] != 0x2222) { ok = false; break; }
					if (bits[i++] != 0x3333) { ok = false; break; }
					if (bits[i++] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(1, img.Bits.Length);
				Assert.NotNull(img.Bits[0]);
				Assert.AreEqual(1234 * 345 * 4, img.Bits[0].Length);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);

				bool ok = true;
				var bits = img.Bits[0];
				for (int i = 0; i < bits.Length; i++)
				{
					if (bits[i] != 0) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init false
			{
				var img = new Image16(1234, 345, true, true, false, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.Null(img.Bits);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(5, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 71 * 4, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != 0x1111) { ok = false; break; }
						if (bits[i++] != 0x2222) { ok = false; break; }
						if (bits[i++] != 0x3333) { ok = false; break; }
						if (bits[i++] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(5, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 71 * 4, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != 0x1111) { ok = false; break; }
						if (bits[i++] != 0x2222) { ok = false; break; }
						if (bits[i++] != 0x3333) { ok = false; break; }
						if (bits[i++] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(5, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 71 * 4, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length; i++)
					{
						if (bits[i] != 0) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Chunked image with init false
			{
				var img = new ChunkedImage16(1234, 345, true, true, false, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.Null(img.Bits);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);
			}
			#endregion

			#region Tiled image with init color
			{
				var img = new TiledImage16(1234, 345, true, true, 0x4444111122223333, 511, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(15, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(511 * 71 * 4, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != 0x1111) { ok = false; break; }
						if (bits[i++] != 0x2222) { ok = false; break; }
						if (bits[i++] != 0x3333) { ok = false; break; }
						if (bits[i++] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Tiled image with init color array
			{
				var img = new TiledImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 511, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(15, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(511 * 71 * 4, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != 0x1111) { ok = false; break; }
						if (bits[i++] != 0x2222) { ok = false; break; }
						if (bits[i++] != 0x3333) { ok = false; break; }
						if (bits[i++] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(15, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(511 * 71 * 4, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length; i++)
					{
						if (bits[i] != 0) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Tiled image with init false
			{
				var img = new TiledImage16(1234, 345, true, true, false, 511, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.Null(img.Bits);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(4, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 345, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);

				bool ok = true;
				var bitsRed = img.Bits[0];
				var bitsGrn = img.Bits[1];
				var bitsBlu = img.Bits[2];
				var bitsAlp = img.Bits[3];
				for (int i = 0; i < bitsRed.Length; i++)
				{
					if (bitsRed[i] != 0x1111) { ok = false; break; }
					if (bitsGrn[i] != 0x2222) { ok = false; break; }
					if (bitsBlu[i] != 0x3333) { ok = false; break; }
					if (bitsAlp[i] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(4, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 345, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);

				bool ok = true;
				var bitsRed = img.Bits[0];
				var bitsGrn = img.Bits[1];
				var bitsBlu = img.Bits[2];
				var bitsAlp = img.Bits[3];
				for (int i = 0; i < bitsRed.Length; i++)
				{
					if (bitsRed[i] != 0x1111) { ok = false; break; }
					if (bitsGrn[i] != 0x2222) { ok = false; break; }
					if (bitsBlu[i] != 0x3333) { ok = false; break; }
					if (bitsAlp[i] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(4, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 345, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);

				bool ok = true;
				var bitsRed = img.Bits[0];
				var bitsGrn = img.Bits[1];
				var bitsBlu = img.Bits[2];
				var bitsAlp = img.Bits[3];
				for (int i = 0; i < bitsRed.Length; i++)
				{
					if (bitsRed[i] != 0) { ok = false; break; }
					if (bitsGrn[i] != 0) { ok = false; break; }
					if (bitsBlu[i] != 0) { ok = false; break; }
					if (bitsAlp[i] != 0) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init false
			{
				var img = new Image16(1234, 345, true, true, false, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, img.StorageLayout);

				Assert.Null(img.Bits);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(1, img.NumberOfChunks);
				Assert.AreEqual(img.Height, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(1, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(img.Height, img.TileHeight);
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(20, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 71, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length;)
				{
					var bitsRed = img.Bits[a++];
					var bitsGrn = img.Bits[a++];
					var bitsBlu = img.Bits[a++];
					var bitsAlp = img.Bits[a++];
					for (int i = 0; i < bitsRed.Length; i++)
					{
						if (bitsRed[i] != 0x1111) { ok = false; break; }
						if (bitsGrn[i] != 0x2222) { ok = false; break; }
						if (bitsBlu[i] != 0x3333) { ok = false; break; }
						if (bitsAlp[i] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(20, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 71, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length;)
				{
					var bitsRed = img.Bits[a++];
					var bitsGrn = img.Bits[a++];
					var bitsBlu = img.Bits[a++];
					var bitsAlp = img.Bits[a++];
					for (int i = 0; i < bitsRed.Length; i++)
					{
						if (bitsRed[i] != 0x1111) { ok = false; break; }
						if (bitsGrn[i] != 0x2222) { ok = false; break; }
						if (bitsBlu[i] != 0x3333) { ok = false; break; }
						if (bitsAlp[i] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(20, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(1234 * 71, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length; i++)
					{
						if (bits[i] != 0) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Chunked image with init false
			{
				var img = new ChunkedImage16(1234, 345, true, true, false, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Chunked, img.StorageLayout);

				Assert.Null(img.Bits);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(5, img.NumberOfChunks);
				Assert.AreEqual(71, img.ChunkHeight);
				Assert.AreEqual(1, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(img.Width, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);
			}
			#endregion

			#region Tiled image with init color
			{
				var img = new TiledImage16(1234, 345, true, true, 0x4444111122223333, 511, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(60, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(511 * 71, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length;)
				{
					var bitsRed = img.Bits[a++];
					var bitsGrn = img.Bits[a++];
					var bitsBlu = img.Bits[a++];
					var bitsAlp = img.Bits[a++];
					for (int i = 0; i < bitsRed.Length; i++)
					{
						if (bitsRed[i] != 0x1111) { ok = false; break; }
						if (bitsGrn[i] != 0x2222) { ok = false; break; }
						if (bitsBlu[i] != 0x3333) { ok = false; break; }
						if (bitsAlp[i] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Tiled image with init color array
			{
				var img = new TiledImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 511, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(60, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(511 * 71, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length;)
				{
					var bitsRed = img.Bits[a++];
					var bitsGrn = img.Bits[a++];
					var bitsBlu = img.Bits[a++];
					var bitsAlp = img.Bits[a++];
					for (int i = 0; i < bitsRed.Length; i++)
					{
						if (bitsRed[i] != 0x1111) { ok = false; break; }
						if (bitsGrn[i] != 0x2222) { ok = false; break; }
						if (bitsBlu[i] != 0x3333) { ok = false; break; }
						if (bitsAlp[i] != 0x4444) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.NotNull(img.Bits);
				Assert.AreEqual(60, img.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(img.Bits[a]);
					Assert.AreEqual(511 * 71, img.Bits[a].Length);
				}

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);

				bool ok = true;
				for (int a = 0; ok && a < img.Bits.Length; a++)
				{
					var bits = img.Bits[a];
					for (int i = 0; i < bits.Length; i++)
					{
						if (bits[i] != 0) { ok = false; break; }
					}
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Tiled image with init false
			{
				var img = new TiledImage16(1234, 345, true, true, false, 511, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(1234, img.Width);
				Assert.AreEqual(345, img.Height);
				Assert.AreEqual(4, img.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, img.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.Tiled, img.StorageLayout);

				Assert.Null(img.Bits);

				Assert.NotNull(img.ChannelTypes);
				Assert.AreEqual(4, img.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, img.ChannelTypes[3]);

				Assert.AreEqual(3, img.NumberOfTileX);
				Assert.AreEqual(5, img.NumberOfTileY);
				Assert.AreEqual(511, img.TileWidth);
				Assert.AreEqual(71, img.TileHeight);
			}
			#endregion
			#endregion
		}

		[Test]
		public static void Image16GetChunkTest()
		{
			#region GetChunk(chunk)
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(1));

				var chunk = img.GetChunk(0);

				Assert.AreEqual(1234, chunk.Width);
				Assert.AreEqual(345, chunk.Height);
				Assert.AreEqual(4, chunk.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, chunk.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

				Assert.NotNull(chunk.Bits);
				Assert.AreEqual(1, chunk.Bits.Length);
				Assert.NotNull(chunk.Bits[0]);
				Assert.AreEqual(1234 * 345 * 4, chunk.Bits[0].Length);

				Assert.NotNull(chunk.ChannelTypes);
				Assert.AreEqual(4, chunk.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[3]);

				Assert.AreEqual(1, chunk.NumberOfChunks);
				Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
				Assert.AreEqual(1, chunk.NumberOfTileX);
				Assert.AreEqual(1, chunk.NumberOfTileY);
				Assert.AreEqual(chunk.Width, chunk.TileWidth);
				Assert.AreEqual(chunk.Height, chunk.TileHeight);

				bool ok = true;
				var bits = chunk.Bits[0];
				for (int i = 0; i < bits.Length;)
				{
					if (bits[i++] != 0x1111) { ok = false; break; }
					if (bits[i++] != 0x2222) { ok = false; break; }
					if (bits[i++] != 0x3333) { ok = false; break; }
					if (bits[i++] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init false
			{
				var img = new Image16(1234, 345, true, true, false, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(1));

				Assert.Throws(typeof(NullReferenceException), () => img.GetChunk(0));
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(12));

				for (int iChunk = 0; iChunk < img.NumberOfChunks; iChunk++)
				{
					var chunk = img.GetChunk(iChunk);

					Assert.AreEqual(1234, chunk.Width);
					Assert.AreEqual(71, chunk.Height);
					Assert.AreEqual(4, chunk.NumberOfChannels);
					Assert.AreEqual(PlanarConfiguration.Continuously, chunk.PlanarConfiguration);
					Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

					Assert.NotNull(chunk.Bits);
					Assert.AreEqual(1, chunk.Bits.Length);
					Assert.NotNull(chunk.Bits[0]);
					Assert.AreEqual(1234 * 71 * 4, chunk.Bits[0].Length);

					Assert.NotNull(chunk.ChannelTypes);
					Assert.AreEqual(4, chunk.ChannelTypes.Length);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[1]);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[2]);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[3]);

					Assert.AreEqual(1, chunk.NumberOfChunks);
					Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
					Assert.AreEqual(1, chunk.NumberOfTileX);
					Assert.AreEqual(1, chunk.NumberOfTileY);
					Assert.AreEqual(chunk.Width, chunk.TileWidth);
					Assert.AreEqual(chunk.Height, chunk.TileHeight);

					bool ok = true;
					var bits = chunk.Bits[0];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != 0x1111) { ok = false; break; }
						if (bits[i++] != 0x2222) { ok = false; break; }
						if (bits[i++] != 0x3333) { ok = false; break; }
						if (bits[i++] != 0x4444) { ok = false; break; }
					}

					Assert.IsTrue(ok);
				}
			}
			#endregion

			#region Chunked image with init false
			{
				var img = new ChunkedImage16(1234, 345, true, true, false, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(10));

				for (int iChunk = 0; iChunk < img.NumberOfChunks; iChunk++)
					Assert.Throws(typeof(NullReferenceException), () => img.GetChunk(iChunk));
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(1));

				var chunk = img.GetChunk(0);

				Assert.AreEqual(1234, chunk.Width);
				Assert.AreEqual(345, chunk.Height);
				Assert.AreEqual(4, chunk.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, chunk.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

				Assert.NotNull(chunk.Bits);
				Assert.AreEqual(4, chunk.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(chunk.Bits[a]);
					Assert.AreEqual(1234 * 345, chunk.Bits[a].Length);
				}

				Assert.NotNull(chunk.ChannelTypes);
				Assert.AreEqual(4, chunk.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[3]);

				Assert.AreEqual(1, chunk.NumberOfChunks);
				Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
				Assert.AreEqual(1, chunk.NumberOfTileX);
				Assert.AreEqual(1, chunk.NumberOfTileY);
				Assert.AreEqual(chunk.Width, chunk.TileWidth);
				Assert.AreEqual(chunk.Height, chunk.TileHeight);

				bool ok = true;
				var bitsRed = chunk.Bits[0];
				var bitsGrn = chunk.Bits[1];
				var bitsBlu = chunk.Bits[2];
				var bitsAlp = chunk.Bits[3];
				for (int i = 0; i < bitsRed.Length; i++)
				{
					if (bitsRed[i] != 0x1111) { ok = false; break; }
					if (bitsGrn[i] != 0x2222) { ok = false; break; }
					if (bitsBlu[i] != 0x3333) { ok = false; break; }
					if (bitsAlp[i] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init false
			{
				var img = new Image16(1234, 345, true, true, false, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(1));

				Assert.Throws(typeof(NullReferenceException), () => img.GetChunk(0));
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(13));

				for (int iChunk = 0; iChunk < img.NumberOfChunks; iChunk++)
				{
					var chunk = img.GetChunk(iChunk);

					Assert.AreEqual(1234, chunk.Width);
					Assert.AreEqual(71, chunk.Height);
					Assert.AreEqual(4, chunk.NumberOfChannels);
					Assert.AreEqual(PlanarConfiguration.Separated, chunk.PlanarConfiguration);
					Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

					Assert.NotNull(chunk.Bits);
					Assert.AreEqual(4, chunk.Bits.Length);
					for (int a = 0; a < chunk.Bits.Length; a++)
					{
						Assert.NotNull(chunk.Bits[a]);
						Assert.AreEqual(1234 * 71, chunk.Bits[a].Length);
					}

					Assert.NotNull(chunk.ChannelTypes);
					Assert.AreEqual(4, chunk.ChannelTypes.Length);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[1]);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[2]);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[3]);

					Assert.AreEqual(1, chunk.NumberOfChunks);
					Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
					Assert.AreEqual(1, chunk.NumberOfTileX);
					Assert.AreEqual(1, chunk.NumberOfTileY);
					Assert.AreEqual(chunk.Width, chunk.TileWidth);
					Assert.AreEqual(chunk.Height, chunk.TileHeight);

					bool ok = true;
					var bitsRed = chunk.Bits[0];
					var bitsGrn = chunk.Bits[1];
					var bitsBlu = chunk.Bits[2];
					var bitsAlp = chunk.Bits[3];
					for (int i = 0; i < bitsRed.Length; i++)
					{
						if (bitsRed[i] != 0x1111) { ok = false; break; }
						if (bitsGrn[i] != 0x2222) { ok = false; break; }
						if (bitsBlu[i] != 0x3333) { ok = false; break; }
						if (bitsAlp[i] != 0x4444) { ok = false; break; }
					}

					Assert.IsTrue(ok);
				}
			}
			#endregion

			#region Chunked image with init false
			{
				var img = new ChunkedImage16(1234, 345, true, true, false, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(10));

				for (int iChunk = 0; iChunk < img.NumberOfChunks; iChunk++)
					Assert.Throws(typeof(NullReferenceException), () => img.GetChunk(iChunk));
			}
			#endregion
			#endregion
			#endregion

			#region GetChunk(chunk, channel)
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(1, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(0, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					var chunk = img.GetChunk(0, channel);

					Assert.AreEqual(1234, chunk.Width);
					Assert.AreEqual(345, chunk.Height);
					Assert.AreEqual(1, chunk.NumberOfChannels);
					Assert.AreEqual(PlanarConfiguration.Continuously, chunk.PlanarConfiguration);
					Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

					Assert.NotNull(chunk.Bits);
					Assert.AreEqual(1, chunk.Bits.Length);
					Assert.NotNull(chunk.Bits[0]);
					Assert.AreEqual(1234 * 345, chunk.Bits[0].Length);

					Assert.NotNull(chunk.ChannelTypes);
					Assert.AreEqual(1, chunk.ChannelTypes.Length);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);

					Assert.AreEqual(1, chunk.NumberOfChunks);
					Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
					Assert.AreEqual(1, chunk.NumberOfTileX);
					Assert.AreEqual(1, chunk.NumberOfTileY);
					Assert.AreEqual(chunk.Width, chunk.TileWidth);
					Assert.AreEqual(chunk.Height, chunk.TileHeight);

					ushort channelBitsValue = channelBitsValues[channel];

					bool ok = true;
					var bits = chunk.Bits[0];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != channelBitsValue) { ok = false; break; }
					}

					Assert.IsTrue(ok);
				}
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(12, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(2, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					for (int iChunk = 0; iChunk < img.NumberOfChunks; iChunk++)
					{
						var chunk = img.GetChunk(iChunk, channel);

						Assert.AreEqual(1234, chunk.Width);
						Assert.AreEqual(71, chunk.Height);
						Assert.AreEqual(1, chunk.NumberOfChannels);
						Assert.AreEqual(PlanarConfiguration.Continuously, chunk.PlanarConfiguration);
						Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

						Assert.NotNull(chunk.Bits);
						Assert.AreEqual(1, chunk.Bits.Length);
						Assert.NotNull(chunk.Bits[0]);
						Assert.AreEqual(1234 * 71, chunk.Bits[0].Length);

						Assert.NotNull(chunk.ChannelTypes);
						Assert.AreEqual(1, chunk.ChannelTypes.Length);
						Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);

						Assert.AreEqual(1, chunk.NumberOfChunks);
						Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
						Assert.AreEqual(1, chunk.NumberOfTileX);
						Assert.AreEqual(1, chunk.NumberOfTileY);
						Assert.AreEqual(chunk.Width, chunk.TileWidth);
						Assert.AreEqual(chunk.Height, chunk.TileHeight);

						ushort channelBitsValue = channelBitsValues[channel];

						bool ok = true;
						var bits = chunk.Bits[0];
						for (int i = 0; i < bits.Length;)
						{
							if (bits[i++] != channelBitsValue) { ok = false; break; }
						}

						Assert.IsTrue(ok);
					}
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(1, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(0, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					var chunk = img.GetChunk(0, channel);

					Assert.NotNull(chunk.Bits);
					Assert.AreEqual(1, chunk.Bits.Length);
					Assert.NotNull(chunk.Bits[0]);
					Assert.AreEqual(1234 * 345, chunk.Bits[0].Length);

					Assert.NotNull(chunk.ChannelTypes);
					Assert.AreEqual(1, chunk.ChannelTypes.Length);
					Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);

					Assert.AreEqual(1, chunk.NumberOfChunks);
					Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
					Assert.AreEqual(1, chunk.NumberOfTileX);
					Assert.AreEqual(1, chunk.NumberOfTileY);
					Assert.AreEqual(chunk.Width, chunk.TileWidth);
					Assert.AreEqual(chunk.Height, chunk.TileHeight);

					ushort channelBitsValue = channelBitsValues[channel];

					bool ok = true;
					var bits = chunk.Bits[0];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != channelBitsValue) { ok = false; break; }
					}

					Assert.IsTrue(ok);
				}
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Separated);


				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(-3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(12, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetChunk(2, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					for (int iChunk = 0; iChunk < img.NumberOfChunks; iChunk++)
					{
						var chunk = img.GetChunk(iChunk, channel);

						Assert.AreEqual(1234, chunk.Width);
						Assert.AreEqual(71, chunk.Height);
						Assert.AreEqual(1, chunk.NumberOfChannels);
						Assert.AreEqual(PlanarConfiguration.Continuously, chunk.PlanarConfiguration);
						Assert.AreEqual(StorageLayout.SingleChunked, chunk.StorageLayout);

						Assert.NotNull(chunk.Bits);
						Assert.AreEqual(1, chunk.Bits.Length);
						Assert.NotNull(chunk.Bits[0]);
						Assert.AreEqual(1234 * 71, chunk.Bits[0].Length);

						Assert.NotNull(chunk.ChannelTypes);
						Assert.AreEqual(1, chunk.ChannelTypes.Length);
						Assert.AreEqual(ChannelType.UShort, chunk.ChannelTypes[0]);

						Assert.AreEqual(1, chunk.NumberOfChunks);
						Assert.AreEqual(chunk.Height, chunk.ChunkHeight);
						Assert.AreEqual(1, chunk.NumberOfTileX);
						Assert.AreEqual(1, chunk.NumberOfTileY);
						Assert.AreEqual(chunk.Width, chunk.TileWidth);
						Assert.AreEqual(chunk.Height, chunk.TileHeight);

						ushort channelBitsValue = channelBitsValues[channel];

						bool ok = true;
						var bits = chunk.Bits[0];
						for (int i = 0; i < bits.Length;)
						{
							if (bits[i++] != channelBitsValue) { ok = false; break; }
						}

						Assert.IsTrue(ok);
					}
				}
			}
			#endregion
			#endregion
			#endregion
		}

		[Test]
		public static void Image16GetTileTest()
		{
			#region GetTile(x, y)
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 1));

				var tile = img.GetTile(0, 0);

				Assert.AreEqual(1234, tile.Width);
				Assert.AreEqual(345, tile.Height);
				Assert.AreEqual(4, tile.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

				Assert.NotNull(tile.Bits);
				Assert.AreEqual(1, tile.Bits.Length);
				Assert.NotNull(tile.Bits[0]);
				Assert.AreEqual(1234 * 345 * 4, tile.Bits[0].Length);

				Assert.NotNull(tile.ChannelTypes);
				Assert.AreEqual(4, tile.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[3]);

				Assert.AreEqual(1, tile.NumberOfChunks);
				Assert.AreEqual(tile.Height, tile.ChunkHeight);
				Assert.AreEqual(1, tile.NumberOfTileX);
				Assert.AreEqual(1, tile.NumberOfTileY);
				Assert.AreEqual(tile.Width, tile.TileWidth);
				Assert.AreEqual(tile.Height, tile.TileHeight);

				bool ok = true;
				var bits = tile.Bits[0];
				for (int i = 0; i < bits.Length;)
				{
					if (bits[i++] != 0x1111) { ok = false; break; }
					if (bits[i++] != 0x2222) { ok = false; break; }
					if (bits[i++] != 0x3333) { ok = false; break; }
					if (bits[i++] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init false
			{
				var img = new Image16(1234, 345, true, true, false, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, -3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(1, 0));

				Assert.Throws(typeof(NullReferenceException), () => img.GetTile(0, 0));
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-3, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 12));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						var tile = img.GetTile(x, y);

						Assert.AreEqual(1234, tile.Width);
						Assert.AreEqual(71, tile.Height);
						Assert.AreEqual(4, tile.NumberOfChannels);
						Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
						Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

						Assert.NotNull(tile.Bits);
						Assert.AreEqual(1, tile.Bits.Length);
						Assert.NotNull(tile.Bits[0]);
						Assert.AreEqual(1234 * 71 * 4, tile.Bits[0].Length);

						Assert.NotNull(tile.ChannelTypes);
						Assert.AreEqual(4, tile.ChannelTypes.Length);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[1]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[2]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[3]);

						Assert.AreEqual(1, tile.NumberOfChunks);
						Assert.AreEqual(tile.Height, tile.ChunkHeight);
						Assert.AreEqual(1, tile.NumberOfTileX);
						Assert.AreEqual(1, tile.NumberOfTileY);
						Assert.AreEqual(tile.Width, tile.TileWidth);
						Assert.AreEqual(tile.Height, tile.TileHeight);

						bool ok = true;
						var bits = tile.Bits[0];
						for (int i = 0; i < bits.Length;)
						{
							if (bits[i++] != 0x1111) { ok = false; break; }
							if (bits[i++] != 0x2222) { ok = false; break; }
							if (bits[i++] != 0x3333) { ok = false; break; }
							if (bits[i++] != 0x4444) { ok = false; break; }
						}

						Assert.IsTrue(ok);
					}
				}
			}
			#endregion

			#region Chunked image with init false
			{
				var img = new ChunkedImage16(1234, 345, true, true, false, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(3, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(10, 0));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						Assert.Throws(typeof(NullReferenceException), () => img.GetTile(x, y));
					}
				}
			}
			#endregion

			#region Tiled image with init color array
			{
				var img = new TiledImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 511, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-3, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 12));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						var tile = img.GetTile(x, y);

						Assert.AreEqual(511, tile.Width);
						Assert.AreEqual(71, tile.Height);
						Assert.AreEqual(4, tile.NumberOfChannels);
						Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
						Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

						Assert.NotNull(tile.Bits);
						Assert.AreEqual(1, tile.Bits.Length);
						Assert.NotNull(tile.Bits[0]);
						Assert.AreEqual(511 * 71 * 4, tile.Bits[0].Length);

						Assert.NotNull(tile.ChannelTypes);
						Assert.AreEqual(4, tile.ChannelTypes.Length);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[1]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[2]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[3]);

						Assert.AreEqual(1, tile.NumberOfChunks);
						Assert.AreEqual(tile.Height, tile.ChunkHeight);
						Assert.AreEqual(1, tile.NumberOfTileX);
						Assert.AreEqual(1, tile.NumberOfTileY);
						Assert.AreEqual(tile.Width, tile.TileWidth);
						Assert.AreEqual(tile.Height, tile.TileHeight);

						bool ok = true;
						var bits = tile.Bits[0];
						for (int i = 0; i < bits.Length;)
						{
							if (bits[i++] != 0x1111) { ok = false; break; }
							if (bits[i++] != 0x2222) { ok = false; break; }
							if (bits[i++] != 0x3333) { ok = false; break; }
							if (bits[i++] != 0x4444) { ok = false; break; }
						}

						Assert.IsTrue(ok);
					}
				}
			}
			#endregion

			#region Tiled image with init false
			{
				var img = new TiledImage16(1234, 345, true, true, false, 511, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(3, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(10, 0));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						Assert.Throws(typeof(NullReferenceException), () => img.GetTile(x, y));
					}
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 1));

				var tile = img.GetTile(0, 0);

				Assert.AreEqual(1234, tile.Width);
				Assert.AreEqual(345, tile.Height);
				Assert.AreEqual(4, tile.NumberOfChannels);
				Assert.AreEqual(PlanarConfiguration.Separated, tile.PlanarConfiguration);
				Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

				Assert.NotNull(tile.Bits);
				Assert.AreEqual(4, tile.Bits.Length);
				for (int a = 0; a < img.Bits.Length; a++)
				{
					Assert.NotNull(tile.Bits[a]);
					Assert.AreEqual(1234 * 345, tile.Bits[a].Length);
				}

				Assert.NotNull(tile.ChannelTypes);
				Assert.AreEqual(4, tile.ChannelTypes.Length);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[1]);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[2]);
				Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[3]);

				Assert.AreEqual(1, tile.NumberOfChunks);
				Assert.AreEqual(tile.Height, tile.ChunkHeight);
				Assert.AreEqual(1, tile.NumberOfTileX);
				Assert.AreEqual(1, tile.NumberOfTileY);
				Assert.AreEqual(tile.Width, tile.TileWidth);
				Assert.AreEqual(tile.Height, tile.TileHeight);

				bool ok = true;
				var bitsRed = tile.Bits[0];
				var bitsGrn = tile.Bits[1];
				var bitsBlu = tile.Bits[2];
				var bitsAlp = tile.Bits[3];
				for (int i = 0; i < bitsRed.Length; i++)
				{
					if (bitsRed[i] != 0x1111) { ok = false; break; }
					if (bitsGrn[i] != 0x2222) { ok = false; break; }
					if (bitsBlu[i] != 0x3333) { ok = false; break; }
					if (bitsAlp[i] != 0x4444) { ok = false; break; }
				}

				Assert.IsTrue(ok);
			}
			#endregion

			#region Single-chunked image with init false
			{
				var img = new Image16(1234, 345, true, true, false, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, -3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(1, 0));

				Assert.Throws(typeof(NullReferenceException), () => img.GetTile(0, 0));
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-3, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 13));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						var tile = img.GetTile(x, y);

						Assert.AreEqual(1234, tile.Width);
						Assert.AreEqual(71, tile.Height);
						Assert.AreEqual(4, tile.NumberOfChannels);
						Assert.AreEqual(PlanarConfiguration.Separated, tile.PlanarConfiguration);
						Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

						Assert.NotNull(tile.Bits);
						Assert.AreEqual(4, tile.Bits.Length);
						for (int a = 0; a < tile.Bits.Length; a++)
						{
							Assert.NotNull(tile.Bits[a]);
							Assert.AreEqual(1234 * 71, tile.Bits[a].Length);
						}

						Assert.NotNull(tile.ChannelTypes);
						Assert.AreEqual(4, tile.ChannelTypes.Length);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[1]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[2]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[3]);

						Assert.AreEqual(1, tile.NumberOfChunks);
						Assert.AreEqual(tile.Height, tile.ChunkHeight);
						Assert.AreEqual(1, tile.NumberOfTileX);
						Assert.AreEqual(1, tile.NumberOfTileY);
						Assert.AreEqual(tile.Width, tile.TileWidth);
						Assert.AreEqual(tile.Height, tile.TileHeight);

						bool ok = true;
						var bitsRed = tile.Bits[0];
						var bitsGrn = tile.Bits[1];
						var bitsBlu = tile.Bits[2];
						var bitsAlp = tile.Bits[3];
						for (int i = 0; i < bitsRed.Length; i++)
						{
							if (bitsRed[i] != 0x1111) { ok = false; break; }
							if (bitsGrn[i] != 0x2222) { ok = false; break; }
							if (bitsBlu[i] != 0x3333) { ok = false; break; }
							if (bitsAlp[i] != 0x4444) { ok = false; break; }
						}

						Assert.IsTrue(ok);
					}
				}
			}
			#endregion

			#region Chunked image with init false
			{
				var img = new ChunkedImage16(1234, 345, true, true, false, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(3, -3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(16, 0));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						Assert.Throws(typeof(NullReferenceException), () => img.GetTile(x, y));
					}
				}
			}
			#endregion

			#region Tiled image with init color
			{
				var img = new TiledImage16(1234, 345, true, true, 0x4444111122223333, 511, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-3, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 13));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						var tile = img.GetTile(x, y);

						Assert.AreEqual(511, tile.Width);
						Assert.AreEqual(71, tile.Height);
						Assert.AreEqual(4, tile.NumberOfChannels);
						Assert.AreEqual(PlanarConfiguration.Separated, tile.PlanarConfiguration);
						Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

						Assert.NotNull(tile.Bits);
						Assert.AreEqual(4, tile.Bits.Length);
						for (int a = 0; a < tile.Bits.Length; a++)
						{
							Assert.NotNull(tile.Bits[a]);
							Assert.AreEqual(511 * 71, tile.Bits[a].Length);
						}

						Assert.NotNull(tile.ChannelTypes);
						Assert.AreEqual(4, tile.ChannelTypes.Length);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[1]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[2]);
						Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[3]);

						Assert.AreEqual(1, tile.NumberOfChunks);
						Assert.AreEqual(tile.Height, tile.ChunkHeight);
						Assert.AreEqual(1, tile.NumberOfTileX);
						Assert.AreEqual(1, tile.NumberOfTileY);
						Assert.AreEqual(tile.Width, tile.TileWidth);
						Assert.AreEqual(tile.Height, tile.TileHeight);

						bool ok = true;
						var bitsRed = tile.Bits[0];
						var bitsGrn = tile.Bits[1];
						var bitsBlu = tile.Bits[2];
						var bitsAlp = tile.Bits[3];
						for (int i = 0; i < bitsRed.Length; i++)
						{
							if (bitsRed[i] != 0x1111) { ok = false; break; }
							if (bitsGrn[i] != 0x2222) { ok = false; break; }
							if (bitsBlu[i] != 0x3333) { ok = false; break; }
							if (bitsAlp[i] != 0x4444) { ok = false; break; }
						}

						Assert.IsTrue(ok);
					}
				}
			}
			#endregion

			#region Tiled image with init false
			{
				var img = new TiledImage16(1234, 345, true, true, false, 511, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(3, -3));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(16, 0));

				for (int y = 0; y < img.NumberOfTileY; y++)
				{
					for (int x = 0; x < img.NumberOfTileX; x++)
					{
						Assert.Throws(typeof(NullReferenceException), () => img.GetTile(x, y));
					}
				}
			}
			#endregion
			#endregion
			#endregion

			#region GetTile(x, y, channel)
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, -3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(1, 0, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					var tile = img.GetTile(0, 0, channel);

					Assert.AreEqual(1234, tile.Width);
					Assert.AreEqual(345, tile.Height);
					Assert.AreEqual(1, tile.NumberOfChannels);
					Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
					Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

					Assert.NotNull(tile.Bits);
					Assert.AreEqual(1, tile.Bits.Length);
					Assert.NotNull(tile.Bits[0]);
					Assert.AreEqual(1234 * 345, tile.Bits[0].Length);

					Assert.NotNull(tile.ChannelTypes);
					Assert.AreEqual(1, tile.ChannelTypes.Length);
					Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);

					Assert.AreEqual(1, tile.NumberOfChunks);
					Assert.AreEqual(tile.Height, tile.ChunkHeight);
					Assert.AreEqual(1, tile.NumberOfTileX);
					Assert.AreEqual(1, tile.NumberOfTileY);
					Assert.AreEqual(tile.Width, tile.TileWidth);
					Assert.AreEqual(tile.Height, tile.TileHeight);

					ushort channelBitsValue = channelBitsValues[channel];

					bool ok = true;
					var bits = tile.Bits[0];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != channelBitsValue) { ok = false; break; }
					}

					Assert.IsTrue(ok);
				}
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-4, 0, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(21, 0, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 1, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					for (int y = 0; y < img.NumberOfTileY; y++)
					{
						for (int x = 0; x < img.NumberOfTileX; x++)
						{
							var tile = img.GetTile(x, y, channel);

							Assert.AreEqual(1234, tile.Width);
							Assert.AreEqual(71, tile.Height);
							Assert.AreEqual(1, tile.NumberOfChannels);
							Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
							Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

							Assert.NotNull(tile.Bits);
							Assert.AreEqual(1, tile.Bits.Length);
							Assert.NotNull(tile.Bits[0]);
							Assert.AreEqual(1234 * 71, tile.Bits[0].Length);

							Assert.NotNull(tile.ChannelTypes);
							Assert.AreEqual(1, tile.ChannelTypes.Length);
							Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);

							Assert.AreEqual(1, tile.NumberOfChunks);
							Assert.AreEqual(tile.Height, tile.ChunkHeight);
							Assert.AreEqual(1, tile.NumberOfTileX);
							Assert.AreEqual(1, tile.NumberOfTileY);
							Assert.AreEqual(tile.Width, tile.TileWidth);
							Assert.AreEqual(tile.Height, tile.TileHeight);

							ushort channelBitsValue = channelBitsValues[channel];

							bool ok = true;
							var bits = tile.Bits[0];
							for (int i = 0; i < bits.Length;)
							{
								if (bits[i++] != channelBitsValue) { ok = false; break; }
							}

							Assert.IsTrue(ok);
						}
					}
				}
			}
			#endregion

			#region Tiled image with init color array
			{
				var img = new TiledImage16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, 511, 71, PlanarConfiguration.Continuously);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-4, 0, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(21, 0, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 1, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					for (int y = 0; y < img.NumberOfTileY; y++)
					{
						for (int x = 0; x < img.NumberOfTileX; x++)
						{
							var tile = img.GetTile(x, y, channel);

							Assert.AreEqual(511, tile.Width);
							Assert.AreEqual(71, tile.Height);
							Assert.AreEqual(1, tile.NumberOfChannels);
							Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
							Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

							Assert.NotNull(tile.Bits);
							Assert.AreEqual(1, tile.Bits.Length);
							Assert.NotNull(tile.Bits[0]);
							Assert.AreEqual(511 * 71, tile.Bits[0].Length);

							Assert.NotNull(tile.ChannelTypes);
							Assert.AreEqual(1, tile.ChannelTypes.Length);
							Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);

							Assert.AreEqual(1, tile.NumberOfChunks);
							Assert.AreEqual(tile.Height, tile.ChunkHeight);
							Assert.AreEqual(1, tile.NumberOfTileX);
							Assert.AreEqual(1, tile.NumberOfTileY);
							Assert.AreEqual(tile.Width, tile.TileWidth);
							Assert.AreEqual(tile.Height, tile.TileHeight);

							ushort channelBitsValue = channelBitsValues[channel];

							bool ok = true;
							var bits = tile.Bits[0];
							for (int i = 0; i < bits.Length;)
							{
								if (bits[i++] != channelBitsValue) { ok = false; break; }
							}

							Assert.IsTrue(ok);
						}
					}
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 }, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, -3, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(1, 0, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					var tile = img.GetTile(0, 0, channel);

					Assert.AreEqual(1234, tile.Width);
					Assert.AreEqual(345, tile.Height);
					Assert.AreEqual(1, tile.NumberOfChannels);
					Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
					Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

					Assert.NotNull(tile.Bits);
					Assert.AreEqual(1, tile.Bits.Length);
					Assert.NotNull(tile.Bits[0]);
					Assert.AreEqual(1234 * 345, tile.Bits[0].Length);

					Assert.NotNull(tile.ChannelTypes);
					Assert.AreEqual(1, tile.ChannelTypes.Length);
					Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);

					Assert.AreEqual(1, tile.NumberOfChunks);
					Assert.AreEqual(tile.Height, tile.ChunkHeight);
					Assert.AreEqual(1, tile.NumberOfTileX);
					Assert.AreEqual(1, tile.NumberOfTileY);
					Assert.AreEqual(tile.Width, tile.TileWidth);
					Assert.AreEqual(tile.Height, tile.TileHeight);

					ushort channelBitsValue = channelBitsValues[channel];

					bool ok = true;
					var bits = tile.Bits[0];
					for (int i = 0; i < bits.Length;)
					{
						if (bits[i++] != channelBitsValue) { ok = false; break; }
					}

					Assert.IsTrue(ok);
				}
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-4, 0, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(21, 0, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 1, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					for (int y = 0; y < img.NumberOfTileY; y++)
					{
						for (int x = 0; x < img.NumberOfTileX; x++)
						{
							var tile = img.GetTile(x, y, channel);

							Assert.AreEqual(1234, tile.Width);
							Assert.AreEqual(71, tile.Height);
							Assert.AreEqual(1, tile.NumberOfChannels);
							Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
							Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

							Assert.NotNull(tile.Bits);
							Assert.AreEqual(1, tile.Bits.Length);
							Assert.NotNull(tile.Bits[0]);
							Assert.AreEqual(1234 * 71, tile.Bits[0].Length);

							Assert.NotNull(tile.ChannelTypes);
							Assert.AreEqual(1, tile.ChannelTypes.Length);
							Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);

							Assert.AreEqual(1, tile.NumberOfChunks);
							Assert.AreEqual(tile.Height, tile.ChunkHeight);
							Assert.AreEqual(1, tile.NumberOfTileX);
							Assert.AreEqual(1, tile.NumberOfTileY);
							Assert.AreEqual(tile.Width, tile.TileWidth);
							Assert.AreEqual(tile.Height, tile.TileHeight);

							ushort channelBitsValue = channelBitsValues[channel];

							bool ok = true;
							var bits = tile.Bits[0];
							for (int i = 0; i < bits.Length;)
							{
								if (bits[i++] != channelBitsValue) { ok = false; break; }
							}

							Assert.IsTrue(ok);
						}
					}
				}
			}
			#endregion

			#region Tiled image with init color
			{
				var img = new TiledImage16(1234, 345, true, true, 0x4444111122223333, 511, 71, PlanarConfiguration.Separated);

				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(-4, 0, 0));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(21, 0, 1));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 0, -2));
				Assert.Throws(typeof(ArgumentOutOfRangeException), () => img.GetTile(0, 1, 7));

				ushort[] channelBitsValues = { 0x1111, 0x2222, 0x3333, 0x4444 };
				for (int channel = 0; channel < img.NumberOfChannels; channel++)
				{
					for (int y = 0; y < img.NumberOfTileY; y++)
					{
						for (int x = 0; x < img.NumberOfTileX; x++)
						{
							var tile = img.GetTile(x, y, channel);

							Assert.AreEqual(511, tile.Width);
							Assert.AreEqual(71, tile.Height);
							Assert.AreEqual(1, tile.NumberOfChannels);
							Assert.AreEqual(PlanarConfiguration.Continuously, tile.PlanarConfiguration);
							Assert.AreEqual(StorageLayout.SingleChunked, tile.StorageLayout);

							Assert.NotNull(tile.Bits);
							Assert.AreEqual(1, tile.Bits.Length);
							Assert.NotNull(tile.Bits[0]);
							Assert.AreEqual(511 * 71, tile.Bits[0].Length);

							Assert.NotNull(tile.ChannelTypes);
							Assert.AreEqual(1, tile.ChannelTypes.Length);
							Assert.AreEqual(ChannelType.UShort, tile.ChannelTypes[0]);

							Assert.AreEqual(1, tile.NumberOfChunks);
							Assert.AreEqual(tile.Height, tile.ChunkHeight);
							Assert.AreEqual(1, tile.NumberOfTileX);
							Assert.AreEqual(1, tile.NumberOfTileY);
							Assert.AreEqual(tile.Width, tile.TileWidth);
							Assert.AreEqual(tile.Height, tile.TileHeight);

							ushort channelBitsValue = channelBitsValues[channel];

							bool ok = true;
							var bits = tile.Bits[0];
							for (int i = 0; i < bits.Length;)
							{
								if (bits[i++] != channelBitsValue) { ok = false; break; }
							}

							Assert.IsTrue(ok);
						}
					}
				}
			}
			#endregion
			#endregion
			#endregion
		}

		[Test]
		public static void Image16IndexPropertyTest()
		{
			ushort[] channelValues = new ushort[] { 0x1111, 0x2222, 0x3333, 0x4444 };

			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init color
			{
				var img = new Image16(1234, 345, true, true, 0x4444111122223333, PlanarConfiguration.Continuously);

				Assert.AreEqual(0x4444111122223333, img[0, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 100]);
				Assert.AreEqual(0x4444111122223333, img[1233, 344]);

				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[-3, 0]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[0, -1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[1234, 1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[14, 345]; });

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);

					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, -3, 0]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 0, -1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 1234, 1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 14, 345]; });
				}
			}
			#endregion

			#region Chunked image with init color array
			{
				var img = new ChunkedImage16(1234, 345, true, true, channelValues, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(0x4444111122223333, img[0, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 100]);
				Assert.AreEqual(0x4444111122223333, img[1233, 344]);

				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[-3, 0]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[0, -1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[1234, 1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[14, 345]; });

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);

					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, -3, 0]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 0, -1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 1234, 1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 14, 345]; });
				}
			}
			#endregion

			#region Tiled image with init color array
			{
				var img = new TiledImage16(1234, 345, true, true, channelValues, 511, 71, PlanarConfiguration.Continuously);

				Assert.AreEqual(0x4444111122223333, img[0, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 100]);
				Assert.AreEqual(0x4444111122223333, img[1233, 344]);

				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[-3, 0]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[0, -1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[1234, 1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[14, 345]; });

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);

					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, -3, 0]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 0, -1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 1234, 1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 14, 345]; });
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init color array
			{
				var img = new Image16(1234, 345, true, true, channelValues, PlanarConfiguration.Separated);

				Assert.AreEqual(0x4444111122223333, img[0, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 100]);
				Assert.AreEqual(0x4444111122223333, img[1233, 344]);

				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[-3, 0]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[0, -1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[1234, 1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[14, 345]; });

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);

					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, -3, 0]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 0, -1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 1234, 1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 14, 345]; });
				}
			}
			#endregion

			#region Chunked image with init color
			{
				var img = new ChunkedImage16(1234, 345, true, true, 0x4444111122223333, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(0x4444111122223333, img[0, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 100]);
				Assert.AreEqual(0x4444111122223333, img[1233, 344]);

				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[-3, 0]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[0, -1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[1234, 1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[14, 345]; });

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);

					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, -3, 0]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 0, -1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 1234, 1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 14, 345]; });
				}
			}
			#endregion

			#region Tiled image with init color
			{
				var img = new TiledImage16(1234, 345, true, true, 0x4444111122223333, 511, 71, PlanarConfiguration.Separated);

				Assert.AreEqual(0x4444111122223333, img[0, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 0]);
				Assert.AreEqual(0x4444111122223333, img[100, 100]);
				Assert.AreEqual(0x4444111122223333, img[1233, 344]);

				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[-3, 0]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[0, -1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[1234, 1]; });
				Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[14, 345]; });

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);

					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, -3, 0]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 0, -1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 1234, 1]; });
					Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = img[i, 14, 345]; });
				}
			}
			#endregion
			#endregion
		}

		[Test]
		public static void Image16ClearTest()
		{
			ushort[] channelValues = new ushort[] { 0x14, 0x23, 0x32, 0x41 };

			long color = 0x0041001400230032;

			#region Clear(channelValues)
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Continuously);

				img.Clear(channelValues);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Continuously);

				img.Clear(channelValues);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Continuously);

				img.Clear(channelValues);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Separated);

				img.Clear(channelValues);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Separated);

				img.Clear(channelValues);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Separated);

				img.Clear(channelValues);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion
			#endregion
			#endregion

			#region Clear(color)
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Continuously);

				img.Clear(color);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Continuously);

				img.Clear(color);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Continuously);

				img.Clear(color);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Separated);

				img.Clear(color);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Separated);

				img.Clear(color);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Separated);

				img.Clear(color);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion
			#endregion
			#endregion
		}

		[Test]
		public static void Image16ClearChannelTest()
		{
			ushort newBlue = 0x3210;
			ushort[] channelValues = new ushort[] { 0, 0, newBlue, 0 };

			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Continuously);

				img.ClearChannel(2, newBlue);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Continuously);

				img.ClearChannel(2, newBlue);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Continuously);

				img.ClearChannel(2, newBlue);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, true, PlanarConfiguration.Separated);

				img.ClearChannel(2, newBlue);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, true, 71, PlanarConfiguration.Separated);

				img.ClearChannel(2, newBlue);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, true, 511, 71, PlanarConfiguration.Separated);

				img.ClearChannel(2, newBlue);

				for (int i = 0; i < 4; i++)
				{
					var channelValue = channelValues[i];
					Assert.AreEqual(channelValue, img[i, 0, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 0]);
					Assert.AreEqual(channelValue, img[i, 100, 100]);
					Assert.AreEqual(channelValue, img[i, 1233, 344]);
				}
			}
			#endregion
			#endregion
		}

		[Test]
		public static void Image16RemoveExtraChannelTest()
		{
			ushort[] channelValues = new ushort[] { 0x14, 0x23, 0x32, 0x41 };

			#region RGBX => RGB
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, channelValues, PlanarConfiguration.Continuously);

				var rgb = img.ExtraChannelRemoved();

				Assert.IsInstanceOf<Image16>(rgb);

				Assert.AreEqual(img.Width, rgb.Width);
				Assert.AreEqual(img.Height, rgb.Height);
				Assert.AreEqual(3, rgb.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, rgb.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, rgb.StorageLayout);

				for (int i = 0; i < 3; i++) Assert.AreEqual(img.ChannelTypes[i], rgb.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, rgb.TileWidth);
				Assert.AreEqual(img.TileHeight, rgb.TileHeight);
				Assert.AreEqual(img.NumberOfTileX, rgb.NumberOfTileX);
				Assert.AreEqual(img.NumberOfTileY, rgb.NumberOfTileY);

				Assert.AreEqual(img.NumberOfChunks, ((Image16)rgb).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((Image16)rgb).ChunkHeight);

				for (int i = 0; i < 3; i++)
				{
					Assert.AreEqual(img[i, 100, 123], rgb[i, 100, 123]);
					Assert.AreEqual(img[i, 234, 99], rgb[i, 234, 99]);
					Assert.AreEqual(img[i, 432, 210], rgb[i, 432, 210]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, channelValues, 71, PlanarConfiguration.Continuously);

				var rgb = img.ExtraChannelRemoved();

				Assert.IsInstanceOf<ChunkedImage16>(rgb);
				Assert.IsNotInstanceOf<Image16>(rgb);

				Assert.AreEqual(img.Width, rgb.Width);
				Assert.AreEqual(img.Height, rgb.Height);
				Assert.AreEqual(3, rgb.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, rgb.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, rgb.StorageLayout);

				for (int i = 0; i < 3; i++) Assert.AreEqual(img.ChannelTypes[i], rgb.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, rgb.TileWidth);
				Assert.AreEqual(img.TileHeight, rgb.TileHeight);
				Assert.AreEqual(img.NumberOfTileX, rgb.NumberOfTileX);
				Assert.AreEqual(img.NumberOfTileY, rgb.NumberOfTileY);

				Assert.AreEqual(img.NumberOfChunks, ((ChunkedImage16)rgb).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)rgb).ChunkHeight);

				for (int i = 0; i < 3; i++)
				{
					Assert.AreEqual(img[i, 100, 123], rgb[i, 100, 123]);
					Assert.AreEqual(img[i, 234, 99], rgb[i, 234, 99]);
					Assert.AreEqual(img[i, 432, 210], rgb[i, 432, 210]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, channelValues, 511, 71, PlanarConfiguration.Continuously);

				var rgb = img.ExtraChannelRemoved();

				Assert.IsNotInstanceOf<ChunkedImage16>(rgb);

				Assert.AreEqual(img.Width, rgb.Width);
				Assert.AreEqual(img.Height, rgb.Height);
				Assert.AreEqual(3, rgb.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, rgb.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, rgb.StorageLayout);

				for (int i = 0; i < 3; i++) Assert.AreEqual(img.ChannelTypes[i], rgb.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, rgb.TileWidth);
				Assert.AreEqual(img.TileHeight, rgb.TileHeight);
				Assert.AreEqual(img.NumberOfTileX, rgb.NumberOfTileX);
				Assert.AreEqual(img.NumberOfTileY, rgb.NumberOfTileY);

				for (int i = 0; i < 3; i++)
				{
					Assert.AreEqual(img[i, 100, 123], rgb[i, 100, 123]);
					Assert.AreEqual(img[i, 234, 99], rgb[i, 234, 99]);
					Assert.AreEqual(img[i, 432, 210], rgb[i, 432, 210]);
				}
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, true, channelValues, PlanarConfiguration.Separated);

				var rgb = img.ExtraChannelRemoved();

				Assert.IsInstanceOf<Image16>(rgb);

				Assert.AreEqual(img.Width, rgb.Width);
				Assert.AreEqual(img.Height, rgb.Height);
				Assert.AreEqual(3, rgb.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, rgb.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, rgb.StorageLayout);

				for (int i = 0; i < 3; i++) Assert.AreEqual(img.ChannelTypes[i], rgb.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, rgb.TileWidth);
				Assert.AreEqual(img.TileHeight, rgb.TileHeight);
				Assert.AreEqual(img.NumberOfTileX, rgb.NumberOfTileX);
				Assert.AreEqual(img.NumberOfTileY, rgb.NumberOfTileY);

				Assert.AreEqual(img.NumberOfChunks, ((Image16)rgb).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((Image16)rgb).ChunkHeight);

				for (int i = 0; i < 3; i++)
				{
					Assert.AreEqual(img[i, 100, 123], rgb[i, 100, 123]);
					Assert.AreEqual(img[i, 234, 99], rgb[i, 234, 99]);
					Assert.AreEqual(img[i, 432, 210], rgb[i, 432, 210]);
				}
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, true, channelValues, 71, PlanarConfiguration.Separated);

				var rgb = img.ExtraChannelRemoved();

				Assert.IsInstanceOf<ChunkedImage16>(rgb);
				Assert.IsNotInstanceOf<Image16>(rgb);

				Assert.AreEqual(img.Width, rgb.Width);
				Assert.AreEqual(img.Height, rgb.Height);
				Assert.AreEqual(3, rgb.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, rgb.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, rgb.StorageLayout);

				for (int i = 0; i < 3; i++) Assert.AreEqual(img.ChannelTypes[i], rgb.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, rgb.TileWidth);
				Assert.AreEqual(img.TileHeight, rgb.TileHeight);
				Assert.AreEqual(img.NumberOfTileX, rgb.NumberOfTileX);
				Assert.AreEqual(img.NumberOfTileY, rgb.NumberOfTileY);

				Assert.AreEqual(img.NumberOfChunks, ((ChunkedImage16)rgb).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)rgb).ChunkHeight);

				for (int i = 0; i < 3; i++)
				{
					Assert.AreEqual(img[i, 100, 123], rgb[i, 100, 123]);
					Assert.AreEqual(img[i, 234, 99], rgb[i, 234, 99]);
					Assert.AreEqual(img[i, 432, 210], rgb[i, 432, 210]);
				}
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, true, channelValues, 511, 71, PlanarConfiguration.Separated);

				var rgb = img.ExtraChannelRemoved();

				Assert.IsNotInstanceOf<ChunkedImage16>(rgb);

				Assert.AreEqual(img.Width, rgb.Width);
				Assert.AreEqual(img.Height, rgb.Height);
				Assert.AreEqual(3, rgb.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, rgb.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, rgb.StorageLayout);

				for (int i = 0; i < 3; i++) Assert.AreEqual(img.ChannelTypes[i], rgb.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, rgb.TileWidth);
				Assert.AreEqual(img.TileHeight, rgb.TileHeight);
				Assert.AreEqual(img.NumberOfTileX, rgb.NumberOfTileX);
				Assert.AreEqual(img.NumberOfTileY, rgb.NumberOfTileY);

				for (int i = 0; i < 3; i++)
				{
					Assert.AreEqual(img[i, 100, 123], rgb[i, 100, 123]);
					Assert.AreEqual(img[i, 234, 99], rgb[i, 234, 99]);
					Assert.AreEqual(img[i, 432, 210], rgb[i, 432, 210]);
				}
			}
			#endregion
			#endregion
			#endregion

			channelValues = new ushort[] { 0x14, 0x23, 0x32 };

			#region RGB == RGB
			#region PlanarConfiguration.Continuously
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, false, channelValues, PlanarConfiguration.Continuously);

				var rgb = img.ExtraChannelRemoved();

				Assert.AreSame(img, rgb);
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, false, channelValues, 71, PlanarConfiguration.Continuously);

				var rgb = img.ExtraChannelRemoved();

				Assert.AreSame(img, rgb);
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, false, channelValues, 511, 71, PlanarConfiguration.Continuously);

				var rgb = img.ExtraChannelRemoved();

				Assert.AreSame(img, rgb);
			}
			#endregion
			#endregion

			#region PlanarConfiguration.Separated
			#region Single-chunked image with init true
			{
				var img = new Image16(1234, 345, true, false, channelValues, PlanarConfiguration.Separated);

				var rgb = img.ExtraChannelRemoved();

				Assert.AreSame(img, rgb);
			}
			#endregion

			#region Chunked image with init true
			{
				var img = new ChunkedImage16(1234, 345, true, false, channelValues, 71, PlanarConfiguration.Separated);

				var rgb = img.ExtraChannelRemoved();

				Assert.AreSame(img, rgb);
			}
			#endregion

			#region Tiled image with init true
			{
				var img = new TiledImage16(1234, 345, true, false, channelValues, 511, 71, PlanarConfiguration.Separated);

				var rgb = img.ExtraChannelRemoved();

				Assert.AreSame(img, rgb);
			}
			#endregion
			#endregion
			#endregion
		}

		[Test]
		public static void Image16DrawTest()
		{
			#region RGBX(C) into RGBX(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(S) into RGBX(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(C) into RGBX(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(S) into RGBX(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(C) into RGB(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(S) into RGB(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(C) into RGB(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(S) into RGB(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { ushort.MaxValue, 0, 0, 0x23 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(C) into RGBX(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4 && channel != 3) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(S) into RGBX(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4 && channel != 3) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(C) into RGBX(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4 && channel != 3) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(S) into RGBX(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4 && channel != 3) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(C) into RGB(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(S) into RGB(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(C) into RGB(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGB(S) into RGB(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0 };
				ushort[] initColorSource = { 123, 0, 0 };

				var source = new TiledImage16(4, 4, true, false, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, false, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(C) into Gray
			{
				ushort[] initColorTarget = { 32 };
				ushort[] initColorSource = { 240, 180, 60, 0x23 };
				ushort[] colorSource = { 160 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, false, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, false, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? colorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region RGBX(S) into Gray
			{
				ushort[] initColorTarget = { 32 };
				ushort[] initColorSource = { 240, 180, 60, 0x23 };
				ushort[] colorSource = { 160 };

				var source = new TiledImage16(4, 4, true, true, initColorSource, 5, 3, PlanarConfiguration.Separated);

				{
					var target = new TiledImage16(7, 7, false, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, false, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? colorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region Gray into RGBX(C)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { 123 };
				ushort[] colorSource = { 123, 123, 123, 0 };

				var source = new TiledImage16(4, 4, false, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? colorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region Gray into RGBX(S)
			{
				ushort[] initColorTarget = { 0, ushort.MaxValue, 0, 0 };
				ushort[] initColorSource = { 123 };
				ushort[] colorSource = { 123, 123, 123, 0 };

				var source = new TiledImage16(4, 4, false, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, true, true, initColorTarget, 4, 6, PlanarConfiguration.Separated);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? colorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion

			#region Gray into Gray
			{
				ushort[] initColorTarget = { ushort.MaxValue };
				ushort[] initColorSource = { 123 };

				var source = new TiledImage16(4, 4, false, false, initColorSource, 5, 3, PlanarConfiguration.Continuously);

				{
					var target = new TiledImage16(7, 7, false, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

					// No-ops, because out side of target image.
					target.Draw(-4, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, -4, source, DrawBlendMode.Overwrite);
					target.Draw(7, 1, source, DrawBlendMode.Overwrite);
					target.Draw(1, 7, source, DrawBlendMode.Overwrite);
				}

				for (int oy = -3; oy < 7; oy++)
				{
					for (int ox = -3; ox < 7; ox++)
					{
						// We always need a new target, since we will change it every time.
						var target = new TiledImage16(7, 7, false, false, initColorTarget, 4, 6, PlanarConfiguration.Continuously);

						target.Draw(ox, oy, source, DrawBlendMode.Overwrite);

						for (int y = 0; y < target.Height; y++)
						{
							for (int x = 0; x < target.Width; x++)
							{
								for (int channel = 0; channel < target.NumberOfChannels; channel++)
									Assert.AreEqual((x >= ox && x < ox + 4 && y >= oy && y < oy + 4) ? initColorSource[channel] : initColorTarget[channel], target[channel, x, y]);
							}
						}
					}
				}
			}
			#endregion
		}

		[Test]
		public static void Image16GetSubImageTest()
		{
			ushort[] initColor = { 0x11, 0x22, 0x33, 0x44 };

			#region Single-chunked Image
			{
				var img = new Image16(27, 17, true, true, initColor, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 4, 5);

				Assert.IsInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(5, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(5, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(1, sub.NumberOfTileY);

				Assert.AreEqual(1, ((Image16)sub).NumberOfChunks);
				Assert.AreEqual(5, ((Image16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new Image16(27, 17, true, true, initColor, PlanarConfiguration.Separated);

				var sub = img.GetSubImage(2, 3, 4, 5);

				Assert.IsInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(5, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(5, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(1, sub.NumberOfTileY);

				Assert.AreEqual(1, ((Image16)sub).NumberOfChunks);
				Assert.AreEqual(5, ((Image16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new Image16(27, 17, true, false, initColor, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 4, 5);

				Assert.IsInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(5, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(5, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(1, sub.NumberOfTileY);

				Assert.AreEqual(1, ((Image16)sub).NumberOfChunks);
				Assert.AreEqual(5, ((Image16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new Image16(27, 17, true, false, initColor, PlanarConfiguration.Separated);

				var sub = img.GetSubImage(2, 3, 4, 5);

				Assert.IsInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(5, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(5, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(1, sub.NumberOfTileY);

				Assert.AreEqual(1, ((Image16)sub).NumberOfChunks);
				Assert.AreEqual(5, ((Image16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new Image16(27, 17, false, false, initColor, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 4, 5);

				Assert.IsInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(5, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(5, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(1, sub.NumberOfTileY);

				Assert.AreEqual(1, ((Image16)sub).NumberOfChunks);
				Assert.AreEqual(5, ((Image16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}
			#endregion

			#region Chunked Image
			{
				var img = new ChunkedImage16(27, 17, true, true, initColor, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 4, 7);

				Assert.IsInstanceOf<ChunkedImage16>(sub);
				Assert.IsNotInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				Assert.AreEqual(2, ((ChunkedImage16)sub).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new ChunkedImage16(27, 17, true, true, initColor, 6, PlanarConfiguration.Separated);

				var sub = img.GetSubImage(2, 3, 4, 7);

				Assert.IsInstanceOf<ChunkedImage16>(sub);
				Assert.IsNotInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				Assert.AreEqual(2, ((ChunkedImage16)sub).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new ChunkedImage16(27, 17, true, false, initColor, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 4, 7);

				Assert.IsInstanceOf<ChunkedImage16>(sub);
				Assert.IsNotInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				Assert.AreEqual(2, ((ChunkedImage16)sub).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new ChunkedImage16(27, 17, true, false, initColor, 6, PlanarConfiguration.Separated);

				var sub = img.GetSubImage(2, 3, 4, 7);

				Assert.IsInstanceOf<ChunkedImage16>(sub);
				Assert.IsNotInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				Assert.AreEqual(2, ((ChunkedImage16)sub).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new ChunkedImage16(27, 17, false, false, initColor, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 4, 7);

				Assert.IsInstanceOf<ChunkedImage16>(sub);
				Assert.IsNotInstanceOf<Image16>(sub);

				Assert.AreEqual(4, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(4, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(1, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				Assert.AreEqual(2, ((ChunkedImage16)sub).NumberOfChunks);
				Assert.AreEqual(img.ChunkHeight, ((ChunkedImage16)sub).ChunkHeight);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}
			#endregion

			#region Tiled Image
			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Separated);

				var sub = img.GetSubImage(2, 3, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, true, false, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, true, false, initColor, 4, 6, PlanarConfiguration.Separated);

				var sub = img.GetSubImage(2, 3, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, false, false, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 3, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}
			#endregion

			#region Outside
			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(52, 53, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(0, sub[channel, x, y]);
						}
					}
				}
			}
			#endregion

			#region Border
			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(-5, 2, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(x < 5 ? 0 : initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(23, 2, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(x > 3 ? 0 : initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, -3, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(y < 3 ? 0 : initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}

			{
				var img = new TiledImage16(27, 17, true, true, initColor, 4, 6, PlanarConfiguration.Continuously);

				var sub = img.GetSubImage(2, 13, 5, 7);

				Assert.IsInstanceOf<TiledImage16>(sub);
				Assert.IsNotInstanceOf<ChunkedImage16>(sub);

				Assert.AreEqual(5, sub.Width);
				Assert.AreEqual(7, sub.Height);
				Assert.AreEqual(img.NumberOfChannels, sub.NumberOfChannels);
				Assert.AreEqual(img.PlanarConfiguration, sub.PlanarConfiguration);
				Assert.AreEqual(img.StorageLayout, sub.StorageLayout);

				for (int i = 0; i < sub.NumberOfChannels; i++) Assert.AreEqual(img.ChannelTypes[i], sub.ChannelTypes[i]);

				Assert.AreEqual(img.TileWidth, sub.TileWidth);
				Assert.AreEqual(img.TileHeight, sub.TileHeight);
				Assert.AreEqual(2, sub.NumberOfTileX);
				Assert.AreEqual(2, sub.NumberOfTileY);

				for (int y = 0; y < sub.Height; y++)
				{
					for (int x = 0; x < sub.Width; x++)
					{
						for (int channel = 0; channel < sub.NumberOfChannels; channel++)
						{
							Assert.AreEqual(y > 3 ? 0 : initColor[channel], sub[channel, x, y]);
						}
					}
				}
			}
			#endregion
		}
	}
}
