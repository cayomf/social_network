
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/18/2019 17:01:24
-- Generated from EDMX file: C:\Users\Beyond Sky\source\repos\PaoDeQueijo2\PaoDeQueijo2\CasaDoPaoDeQueijo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\Beyond Sky\source\repos\PaoDeQueijo2\PaoDeQueijo2\App_Data\MinasGerais.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProfilePost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostSet] DROP CONSTRAINT [FK_ProfilePost];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfileComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_ProfileComment];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfileLike]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeSet] DROP CONSTRAINT [FK_ProfileLike];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfileShare]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShareSet] DROP CONSTRAINT [FK_ProfileShare];
GO
IF OBJECT_ID(N'[dbo].[FK_PostComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_PostComment];
GO
IF OBJECT_ID(N'[dbo].[FK_PostLike]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeSet] DROP CONSTRAINT [FK_PostLike];
GO
IF OBJECT_ID(N'[dbo].[FK_SharePost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostSet] DROP CONSTRAINT [FK_SharePost];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProfileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfileSet];
GO
IF OBJECT_ID(N'[dbo].[PostSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostSet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[LikeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LikeSet];
GO
IF OBJECT_ID(N'[dbo].[ShareSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShareSet];
GO
IF OBJECT_ID(N'[dbo].[FriendshipSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FriendshipSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProfileSet'
CREATE TABLE [dbo].[ProfileSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(500)  NOT NULL,
    [FirstName] nvarchar(500)  NOT NULL,
    [LastName] nvarchar(500)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [PictureUrl] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'PostSet'
CREATE TABLE [dbo].[PostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(500)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Media] nvarchar(500)  NOT NULL,
    [ProfileId] int  NOT NULL,
    [ShareId] int  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(500)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProfileId] int  NOT NULL,
    [PostId] int  NOT NULL
);
GO

-- Creating table 'LikeSet'
CREATE TABLE [dbo].[LikeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Liked] bit  NOT NULL,
    [ProfileId] int  NOT NULL,
    [PostId] int  NOT NULL
);
GO

-- Creating table 'ShareSet'
CREATE TABLE [dbo].[ShareSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [ProfileId] int  NOT NULL
);
GO

-- Creating table 'FriendshipSet'
CREATE TABLE [dbo].[FriendshipSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstUser] nvarchar(500)  NOT NULL,
    [SecondUser] nvarchar(500)  NOT NULL,
    [Accepted] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProfileSet'
ALTER TABLE [dbo].[ProfileSet]
ADD CONSTRAINT [PK_ProfileSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [PK_PostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LikeSet'
ALTER TABLE [dbo].[LikeSet]
ADD CONSTRAINT [PK_LikeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShareSet'
ALTER TABLE [dbo].[ShareSet]
ADD CONSTRAINT [PK_ShareSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FriendshipSet'
ALTER TABLE [dbo].[FriendshipSet]
ADD CONSTRAINT [PK_FriendshipSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProfileId] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_ProfilePost]
    FOREIGN KEY ([ProfileId])
    REFERENCES [dbo].[ProfileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilePost'
CREATE INDEX [IX_FK_ProfilePost]
ON [dbo].[PostSet]
    ([ProfileId]);
GO

-- Creating foreign key on [ProfileId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_ProfileComment]
    FOREIGN KEY ([ProfileId])
    REFERENCES [dbo].[ProfileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfileComment'
CREATE INDEX [IX_FK_ProfileComment]
ON [dbo].[CommentSet]
    ([ProfileId]);
GO

-- Creating foreign key on [ProfileId] in table 'LikeSet'
ALTER TABLE [dbo].[LikeSet]
ADD CONSTRAINT [FK_ProfileLike]
    FOREIGN KEY ([ProfileId])
    REFERENCES [dbo].[ProfileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfileLike'
CREATE INDEX [IX_FK_ProfileLike]
ON [dbo].[LikeSet]
    ([ProfileId]);
GO

-- Creating foreign key on [ProfileId] in table 'ShareSet'
ALTER TABLE [dbo].[ShareSet]
ADD CONSTRAINT [FK_ProfileShare]
    FOREIGN KEY ([ProfileId])
    REFERENCES [dbo].[ProfileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfileShare'
CREATE INDEX [IX_FK_ProfileShare]
ON [dbo].[ShareSet]
    ([ProfileId]);
GO

-- Creating foreign key on [PostId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_PostComment]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[PostSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostComment'
CREATE INDEX [IX_FK_PostComment]
ON [dbo].[CommentSet]
    ([PostId]);
GO

-- Creating foreign key on [PostId] in table 'LikeSet'
ALTER TABLE [dbo].[LikeSet]
ADD CONSTRAINT [FK_PostLike]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[PostSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostLike'
CREATE INDEX [IX_FK_PostLike]
ON [dbo].[LikeSet]
    ([PostId]);
GO

-- Creating foreign key on [ShareId] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_SharePost]
    FOREIGN KEY ([ShareId])
    REFERENCES [dbo].[ShareSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SharePost'
CREATE INDEX [IX_FK_SharePost]
ON [dbo].[PostSet]
    ([ShareId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------