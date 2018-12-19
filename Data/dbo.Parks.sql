USE [dbb1feb347a8564e2a9223a9a7010c7b61]
GO

/****** Object: Table [dbo].[Parks] Script Date: 19/12/2018 14:56:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parks] (
    [Name]                 VARCHAR (50)  NOT NULL,
    [NumberOfSpots]        INT           NOT NULL,
    [NumberOfSpecialSpots] INT           NOT NULL,
    [operationHours]       VARCHAR (50)  NOT NULL,
    [Description]          VARCHAR (100) NOT NULL
);


