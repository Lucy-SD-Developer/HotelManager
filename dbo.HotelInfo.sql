CREATE TABLE [dbo].[HotelInfo] (
    [Id]             INT         NOT NULL IDENTITY,
    [HotelName]      NCHAR (100) NOT NULL,
    [PricePerNight]  MONEY       NULL,
    [AvailableRooms] INT         NULL,
    [BookedRooms]    INT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

