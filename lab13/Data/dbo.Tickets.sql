CREATE TABLE [dbo].[Tickets] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NULL,
    [Hall]  NVARCHAR (MAX) NULL,
    [Price] INT            NOT NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC)
);

