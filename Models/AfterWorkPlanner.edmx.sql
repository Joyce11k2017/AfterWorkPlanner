
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2018 15:24:06
-- Generated from EDMX file: C:\Users\joyce\projects_csharp\WebApplication3\AfterWorkPlanner\Models\AfterWork.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AfterWorkPlanner];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Activity_User_Mapping_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity_User_Mapping] DROP CONSTRAINT [FK_Activity_User_Mapping_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Activity_User_Mapping_ToTable_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity_User_Mapping] DROP CONSTRAINT [FK_Activity_User_Mapping_ToTable_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Roles_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [FK_Roles_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities];
GO
IF OBJECT_ID(N'[dbo].[Activity_User_Mapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity_User_Mapping];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [user_id] int IDENTITY(1,1) NOT NULL,
    [user_name] nvarchar(50)  NULL,
    [user_pwd] nvarchar(50)  NULL,
    [created_dt_tm] datetime  NOT NULL,
    [modified_dt_tm] datetime  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [role_id] int IDENTITY(1,1) NOT NULL,
    [role_name] nvarchar(50)  NULL,
    [user_id] int  NOT NULL,
    [Edit] bit  NOT NULL,
    [Create] bit  NOT NULL,
    [Delete] bit  NOT NULL,
    [View] bit  NOT NULL,
    [created_dt_tm] datetime  NOT NULL,
    [modified_dt_tm] datetime  NOT NULL
);
GO

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [activity_id] int IDENTITY(1,1) NOT NULL,
    [activity_name] nvarchar(50)  NULL,
    [time_limit] decimal(18,2)  NULL
);
GO

-- Creating table 'Activity_User_Mapping'
CREATE TABLE [dbo].[Activity_User_Mapping] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [activity_id] int  NOT NULL,
    [time_limit] decimal(18,2)  NOT NULL,
    [from_time] datetime  NOT NULL,
    [to_time] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [user_id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- Creating primary key on [role_id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([role_id] ASC);
GO

-- Creating primary key on [activity_id] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([activity_id] ASC);
GO

-- Creating primary key on [Id] in table 'Activity_User_Mapping'
ALTER TABLE [dbo].[Activity_User_Mapping]
ADD CONSTRAINT [PK_Activity_User_Mapping]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_Roles_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Roles_Users'
CREATE INDEX [IX_FK_Roles_Users]
ON [dbo].[Roles]
    ([user_id]);
GO

-- Creating foreign key on [activity_id] in table 'Activity_User_Mapping'
ALTER TABLE [dbo].[Activity_User_Mapping]
ADD CONSTRAINT [FK_Activity_User_Mapping_ToTable_1]
    FOREIGN KEY ([activity_id])
    REFERENCES [dbo].[Activities]
        ([activity_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Activity_User_Mapping_ToTable_1'
CREATE INDEX [IX_FK_Activity_User_Mapping_ToTable_1]
ON [dbo].[Activity_User_Mapping]
    ([activity_id]);
GO

-- Creating foreign key on [user_id] in table 'Activity_User_Mapping'
ALTER TABLE [dbo].[Activity_User_Mapping]
ADD CONSTRAINT [FK_Activity_User_Mapping_ToTable]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Activity_User_Mapping_ToTable'
CREATE INDEX [IX_FK_Activity_User_Mapping_ToTable]
ON [dbo].[Activity_User_Mapping]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------