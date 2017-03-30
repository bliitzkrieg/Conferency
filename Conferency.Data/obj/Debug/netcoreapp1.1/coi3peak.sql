IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Conferences] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [Hosted] datetime2 NOT NULL,
    [Location] nvarchar(max),
    [ModifiedAt] datetime2 NOT NULL,
    [Name] nvarchar(max),
    [Website] nvarchar(max),
    CONSTRAINT [PK_Conferences] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Speakers] (
    [Id] int NOT NULL IDENTITY,
    [Bio] nvarchar(max),
    [Company] nvarchar(max),
    [ConferenceId] int,
    [CreatedAt] datetime2 NOT NULL,
    [FullName] nvarchar(max),
    [Github] nvarchar(max),
    [ModifiedAt] datetime2 NOT NULL,
    [Photo] nvarchar(max),
    [Position] nvarchar(max),
    [Twitter] nvarchar(max),
    [Website] nvarchar(max),
    CONSTRAINT [PK_Speakers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Speakers_Conferences_ConferenceId] FOREIGN KEY ([ConferenceId]) REFERENCES [Conferences] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Talks] (
    [Id] int NOT NULL IDENTITY,
    [ConferenceId] int,
    [CreatedAt] datetime2 NOT NULL,
    [Location] nvarchar(max),
    [ModifiedAt] datetime2 NOT NULL,
    [Name] nvarchar(max),
    [Presented] datetime2 NOT NULL,
    [SpeakersId] int,
    [Url] nvarchar(max),
    CONSTRAINT [PK_Talks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Talks_Conferences_ConferenceId] FOREIGN KEY ([ConferenceId]) REFERENCES [Conferences] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Talks_Speakers_SpeakersId] FOREIGN KEY ([SpeakersId]) REFERENCES [Speakers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Speakers_ConferenceId] ON [Speakers] ([ConferenceId]);

GO

CREATE INDEX [IX_Talks_ConferenceId] ON [Talks] ([ConferenceId]);

GO

CREATE INDEX [IX_Talks_SpeakersId] ON [Talks] ([SpeakersId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170330040408_init', N'1.1.0-rtm-22752');

GO

