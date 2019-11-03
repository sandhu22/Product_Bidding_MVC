INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f07ce3f3-e17d-46e0-9455-a824e284cc0f', N'admin@productbids.com', N'ADMIN@PRODUCTBIDS.COM', N'admin@productbids.com', N'ADMIN@PRODUCTBIDS.COM', 0, N'AQAAAAEAACcQAAAAEDiGycAEzvzMEOgvIZ0pkIyoVCOcWHImAVq+Ip6b2P32YUBd6ys7+o9d2bk6hVQETQ==', N'IWVZ2BBGEQMKAND4VPYUUZAGZCU6KG6G', N'b7f1176b-664f-4b4c-9ca3-557edd60d877', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Buyer] ON
INSERT INTO [dbo].[Buyer] ([Id], [BuyerName], [BuyerAccountNumber]) VALUES (1, N'Greg Thomson', N'02-2222-897345-000')
INSERT INTO [dbo].[Buyer] ([Id], [BuyerName], [BuyerAccountNumber]) VALUES (2, N'Frank Hardy', N'02-5555-897345-000')
INSERT INTO [dbo].[Buyer] ([Id], [BuyerName], [BuyerAccountNumber]) VALUES (3, N'Will Davidson ', N'03-4444-897345-000')
SET IDENTITY_INSERT [dbo].[Buyer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [ProductName], [StartingPrice], [IsSold]) VALUES (1, N'Gold Wrist Watch', CAST(1000.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [StartingPrice], [IsSold]) VALUES (2, N'Antique  Artwork', CAST(2000.00 AS Decimal(18, 2)), 0)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [StartingPrice], [IsSold]) VALUES (3, N'Apple iPhone 7', CAST(500.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Seller] ON
INSERT INTO [dbo].[Seller] ([Id], [SellerName], [ContactNumber]) VALUES (1, N'David Hopkins', N'021299567890')
INSERT INTO [dbo].[Seller] ([Id], [SellerName], [ContactNumber]) VALUES (2, N'James Miller', N'021345678345')
SET IDENTITY_INSERT [dbo].[Seller] OFF
SET IDENTITY_INSERT [dbo].[Bid] ON
INSERT INTO [dbo].[Bid] ([Id], [ProductId], [BuyerId], [SellerId], [BidPrice]) VALUES (1, 1, 1, 1, CAST(1500.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Bid] ([Id], [ProductId], [BuyerId], [SellerId], [BidPrice]) VALUES (2, 2, 2, 2, CAST(1600.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Bid] OFF
