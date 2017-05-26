using System;
using Free.Core.Drawing;
using NUnit.Framework;

namespace Free.Core.Tests.Drawing
{
	[TestFixture]
	public class RasterTests
	{
		[Test]
		public static void RasterCreationAndMorphologicalOperatorTests()
		{
			int width = 21;
			int height = 17;
			int tileWidth = 4;
			int tileHeight = 3;

			int tileSize = tileWidth * tileHeight;
			int numberOfTilesX = (width + tileWidth - 1) / tileWidth;
			int numberOfTilesY = (height + tileHeight - 1) / tileHeight;
			int numberOfTiles = numberOfTilesX * numberOfTilesY;

			Raster<bool> raster = new Raster<bool>(width, height, true, tileWidth, tileHeight);

			#region Check raster
			Assert.AreEqual(width, raster.Width);
			Assert.AreEqual(height, raster.Height);
			Assert.AreEqual(1, raster.NumberOfChannels);
			Assert.AreEqual(PlanarConfiguration.Continuously, raster.PlanarConfiguration);

			Assert.AreEqual(StorageLayout.Tiled, raster.StorageLayout);
			Assert.AreEqual(tileWidth, raster.TileWidth);
			Assert.AreEqual(tileHeight, raster.TileHeight);
			Assert.AreEqual(numberOfTilesX, raster.NumberOfTileX);
			Assert.AreEqual(numberOfTilesY, raster.NumberOfTileY);

			Assert.NotNull(raster.ChannelTypes);
			Assert.AreEqual(1, raster.ChannelTypes.Length);
			Assert.AreEqual(ChannelType.Structure, raster.ChannelTypes[0]);

			Assert.NotNull(raster.Data);
			Assert.AreEqual(numberOfTiles, raster.Data.Length);
			for (int i = 0; i < raster.Data.Length; i++)
				Assert.AreEqual(tileSize, raster.Data[i].Length, "raster.Data[{0}]", i);
			#endregion

			for (int i = 0; i < 8; i++)
				raster[i + 4, i + 2] = true;

			var eroded = raster.Erosion(1, true);

			#region Check eroded
			Assert.AreEqual(width, eroded.Width);
			Assert.AreEqual(height, eroded.Height);
			Assert.AreEqual(1, eroded.NumberOfChannels);
			Assert.AreEqual(PlanarConfiguration.Continuously, eroded.PlanarConfiguration);

			Assert.AreEqual(StorageLayout.Tiled, eroded.StorageLayout);
			Assert.AreEqual(tileWidth, eroded.TileWidth);
			Assert.AreEqual(tileHeight, eroded.TileHeight);
			Assert.AreEqual(numberOfTilesX, eroded.NumberOfTileX);
			Assert.AreEqual(numberOfTilesY, eroded.NumberOfTileY);

			Assert.NotNull(eroded.ChannelTypes);
			Assert.AreEqual(1, eroded.ChannelTypes.Length);
			Assert.AreEqual(ChannelType.Structure, eroded.ChannelTypes[0]);

			Assert.NotNull(eroded.Data);
			Assert.AreEqual(numberOfTiles, eroded.Data.Length);
			for (int i = 0; i < eroded.Data.Length; i++)
				Assert.AreEqual(tileSize, eroded.Data[i].Length, "eroded.Data[{0}]", i);
			#endregion

			bool[,] erodedExcepted = new bool[width, height];
			for (int i = 0; i < 8; i++)
			{
				erodedExcepted[i + 4, i + 2] = true;
				erodedExcepted[i + 4, i + 1] = true;
				erodedExcepted[i + 4, i + 3] = true;
				erodedExcepted[i + 3, i + 2] = true;
				erodedExcepted[i + 5, i + 2] = true;
			}

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Assert.AreEqual(erodedExcepted[x, y], eroded[x, y], "eroded[{0}, {1}]", x, y);
				}
			}

			var dilated = eroded.Dilation(1);

			#region Check dilated
			Assert.AreEqual(width, dilated.Width);
			Assert.AreEqual(height, dilated.Height);
			Assert.AreEqual(1, dilated.NumberOfChannels);
			Assert.AreEqual(PlanarConfiguration.Continuously, dilated.PlanarConfiguration);

			Assert.AreEqual(StorageLayout.Tiled, dilated.StorageLayout);
			Assert.AreEqual(tileWidth, dilated.TileWidth);
			Assert.AreEqual(tileHeight, dilated.TileHeight);
			Assert.AreEqual(numberOfTilesX, dilated.NumberOfTileX);
			Assert.AreEqual(numberOfTilesY, dilated.NumberOfTileY);

			Assert.NotNull(dilated.ChannelTypes);
			Assert.AreEqual(1, dilated.ChannelTypes.Length);
			Assert.AreEqual(ChannelType.Structure, dilated.ChannelTypes[0]);

			Assert.NotNull(dilated.Data);
			Assert.AreEqual(numberOfTiles, dilated.Data.Length);
			for (int i = 0; i < dilated.Data.Length; i++)
				Assert.AreEqual(tileSize, dilated.Data[i].Length, "dilated.Data[{0}]", i);
			#endregion

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Assert.AreEqual(raster[x, y], dilated[x, y], "dilated[{0}, {1}]", x, y);
				}
			}

			var dilated2 = eroded.Dilation(2);

			#region Check dilated2
			Assert.AreEqual(width, dilated2.Width);
			Assert.AreEqual(height, dilated2.Height);
			Assert.AreEqual(1, dilated2.NumberOfChannels);
			Assert.AreEqual(PlanarConfiguration.Continuously, dilated2.PlanarConfiguration);

			Assert.AreEqual(StorageLayout.Tiled, dilated2.StorageLayout);
			Assert.AreEqual(tileWidth, dilated2.TileWidth);
			Assert.AreEqual(tileHeight, dilated2.TileHeight);
			Assert.AreEqual(numberOfTilesX, dilated2.NumberOfTileX);
			Assert.AreEqual(numberOfTilesY, dilated2.NumberOfTileY);

			Assert.NotNull(dilated2.ChannelTypes);
			Assert.AreEqual(1, dilated2.ChannelTypes.Length);
			Assert.AreEqual(ChannelType.Structure, dilated2.ChannelTypes[0]);

			Assert.NotNull(dilated2.Data);
			Assert.AreEqual(numberOfTiles, dilated2.Data.Length);
			for (int i = 0; i < dilated2.Data.Length; i++)
				Assert.AreEqual(tileSize, dilated2.Data[i].Length, "dilated2.Data[{0}]", i);
			#endregion

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Assert.AreEqual(false, dilated2[x, y], "dilated2[{0}, {1}] != false", x, y);
				}
			}

			raster.Clear();

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Assert.AreEqual(false, raster[x, y], "raster[{0}, {1}] != false", x, y);
				}
			}

			raster[2, 5] = raster[3, 5] = raster[4, 5] = raster[7, 5] = raster[8, 5] = raster[9, 5] = true;
			raster[2, 6] = raster[9, 6] = true;
			raster[2, 8] = raster[9, 8] = true;
			raster[2, 9] = raster[3, 9] = raster[4, 9] = raster[7, 9] = raster[8, 9] = raster[9, 9] = true;

			var opened = raster.Opening(1.5, true);

			#region Check opened
			Assert.AreEqual(width, opened.Width);
			Assert.AreEqual(height, opened.Height);
			Assert.AreEqual(1, opened.NumberOfChannels);
			Assert.AreEqual(PlanarConfiguration.Continuously, opened.PlanarConfiguration);

			Assert.AreEqual(StorageLayout.Tiled, opened.StorageLayout);
			Assert.AreEqual(tileWidth, opened.TileWidth);
			Assert.AreEqual(tileHeight, opened.TileHeight);
			Assert.AreEqual(numberOfTilesX, opened.NumberOfTileX);
			Assert.AreEqual(numberOfTilesY, opened.NumberOfTileY);

			Assert.NotNull(opened.ChannelTypes);
			Assert.AreEqual(1, opened.ChannelTypes.Length);
			Assert.AreEqual(ChannelType.Structure, opened.ChannelTypes[0]);

			Assert.NotNull(opened.Data);
			Assert.AreEqual(numberOfTiles, opened.Data.Length);
			for (int i = 0; i < opened.Data.Length; i++)
				Assert.AreEqual(tileSize, opened.Data[i].Length, "opened.Data[{0}]", i);
			#endregion

			bool[,] oExp = new bool[width, height];
			oExp[2, 5] = oExp[3, 5] = oExp[4, 5] = oExp[5, 5] = oExp[6, 5] = oExp[7, 5] = oExp[8, 5] = oExp[9, 5] = true;
			oExp[2, 6] = oExp[9, 6] = true;
			oExp[2, 7] = oExp[9, 7] = true;
			oExp[2, 8] = oExp[9, 8] = true;
			oExp[2, 9] = oExp[3, 9] = oExp[4, 9] = oExp[5, 9] = oExp[6, 9] = oExp[7, 9] = oExp[8, 9] = oExp[9, 9] = true;

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Assert.AreEqual(oExp[x, y], opened[x, y], "opened[{0}, {1}]", x, y);
				}
			}

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					raster[x, y] = !raster[x, y];
				}
			}

			var closed = raster.Closing(1.5, true);

			#region Check closed
			Assert.AreEqual(width, closed.Width);
			Assert.AreEqual(height, closed.Height);
			Assert.AreEqual(1, closed.NumberOfChannels);
			Assert.AreEqual(PlanarConfiguration.Continuously, closed.PlanarConfiguration);

			Assert.AreEqual(StorageLayout.Tiled, closed.StorageLayout);
			Assert.AreEqual(tileWidth, closed.TileWidth);
			Assert.AreEqual(tileHeight, closed.TileHeight);
			Assert.AreEqual(numberOfTilesX, closed.NumberOfTileX);
			Assert.AreEqual(numberOfTilesY, closed.NumberOfTileY);

			Assert.NotNull(closed.ChannelTypes);
			Assert.AreEqual(1, closed.ChannelTypes.Length);
			Assert.AreEqual(ChannelType.Structure, closed.ChannelTypes[0]);

			Assert.NotNull(closed.Data);
			Assert.AreEqual(numberOfTiles, closed.Data.Length);
			for (int i = 0; i < closed.Data.Length; i++)
				Assert.AreEqual(tileSize, closed.Data[i].Length, "closed.Data[{0}]", i);
			#endregion

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Assert.AreNotEqual(oExp[x, y], closed[x, y], "closed[{0}, {1}]", x, y);
				}
			}
		}
	}
}
