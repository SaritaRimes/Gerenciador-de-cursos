IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220311122901_PrimeiraMigracao')
BEGIN
    CREATE TABLE [Cursos] (
        [Id] int NOT NULL IDENTITY,
        [Titulo] VARCHAR(100) NOT NULL,
        [DuracaoEmHoras] int NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220311122901_PrimeiraMigracao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220311122901_PrimeiraMigracao', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220311132818_AdicionaUsuarios')
BEGIN
    CREATE TABLE [Usuarios] (
        [Id] int NOT NULL IDENTITY,
        [Username] VARCHAR(50) NOT NULL,
        [Password] VARCHAR(20) NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220311132818_AdicionaUsuarios')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220311132818_AdicionaUsuarios', N'5.0.15');
END;
GO

COMMIT;
GO

