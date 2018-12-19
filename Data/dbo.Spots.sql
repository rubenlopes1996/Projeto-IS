USE [dbb1feb347a8564e2a9223a9a7010c7b61]
GO

/****** Object: Table [dbo].[Spots] Script Date: 19/12/2018 14:57:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Spots] (
    [name]          VARCHAR (5)  NOT NULL,
    [type]          VARCHAR (50) NOT NULL,
    [value]         VARCHAR (50) NOT NULL,
    [timestamp]     DATETIME     NOT NULL,
    [batteryStatus] INT          NOT NULL,
    [id]            VARCHAR (50) NOT NULL,
    [geoLatitude]   VARCHAR (50) NOT NULL,
    [geoLongitude]  VARCHAR (50) NOT NULL
);


