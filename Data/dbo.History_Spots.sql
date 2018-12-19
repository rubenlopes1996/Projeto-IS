USE [dbb1feb347a8564e2a9223a9a7010c7b61]
GO

/****** Object: Table [dbo].[History_Spots] Script Date: 19/12/2018 14:56:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[History_Spots] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [IdSpot]    VARCHAR (50) NOT NULL,
    [Value]     VARCHAR (50) NOT NULL,
    [timestamp] DATETIME     NOT NULL
);


