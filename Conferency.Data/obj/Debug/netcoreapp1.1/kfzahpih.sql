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

ALTER TABLE [Speakers] DROP CONSTRAINT [FK_Speakers_Conferences_ConferenceId];

GO

ALTER TABLE [Talks] DROP CONSTRAINT [FK_Talks_Conferences_ConferenceId];

GO

ALTER TABLE [Talks] DROP CONSTRAINT [FK_Talks_Speakers_SpeakersId];

GO

DROP INDEX [IX_Talks_SpeakersId] ON [Talks];

GO

DROP INDEX [IX_Speakers_ConferenceId] ON [Speakers];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Talks') AND [c].[name] = N'SpeakersId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Talks] DROP COLUMN [SpeakersId];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Speakers') AND [c].[name] = N'ConferenceId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Speakers] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Speakers] DROP COLUMN [ConferenceId];

GO

DROP INDEX [IX_Talks_ConferenceId] ON [Talks];
DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Talks') AND [c].[name] = N'ConferenceId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Talks] ALTER COLUMN [ConferenceId] int NOT NULL;
CREATE INDEX [IX_Talks_ConferenceId] ON [Talks] ([ConferenceId]);

GO

CREATE TABLE [ConferenceSpeaker] (
    [SpeakerId] int NOT NULL,
    [ConferenceId] int NOT NULL,
    CONSTRAINT [PK_ConferenceSpeaker] PRIMARY KEY ([SpeakerId], [ConferenceId]),
    CONSTRAINT [FK_ConferenceSpeaker_Conferences_ConferenceId] FOREIGN KEY ([ConferenceId]) REFERENCES [Conferences] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ConferenceSpeaker_Speakers_SpeakerId] FOREIGN KEY ([SpeakerId]) REFERENCES [Speakers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SpeakerTalk] (
    [SpeakerId] int NOT NULL,
    [TalkId] int NOT NULL,
    CONSTRAINT [PK_SpeakerTalk] PRIMARY KEY ([SpeakerId], [TalkId]),
    CONSTRAINT [FK_SpeakerTalk_Speakers_SpeakerId] FOREIGN KEY ([SpeakerId]) REFERENCES [Speakers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SpeakerTalk_Talks_TalkId] FOREIGN KEY ([TalkId]) REFERENCES [Talks] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ConferenceSpeaker_ConferenceId] ON [ConferenceSpeaker] ([ConferenceId]);

GO

CREATE INDEX [IX_SpeakerTalk_TalkId] ON [SpeakerTalk] ([TalkId]);

GO

ALTER TABLE [Talks] ADD CONSTRAINT [FK_Talks_Conferences_ConferenceId] FOREIGN KEY ([ConferenceId]) REFERENCES [Conferences] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170330044253_AddedRelationships', N'1.1.0-rtm-22752');

GO

ALTER TABLE [Conferences] ADD [Photo] nvarchar(max);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170402052056_AddedPhotoToConference', N'1.1.0-rtm-22752');

GO

ALTER TABLE [ConferenceSpeaker] DROP CONSTRAINT [FK_ConferenceSpeaker_Conferences_ConferenceId];

GO

ALTER TABLE [ConferenceSpeaker] DROP CONSTRAINT [FK_ConferenceSpeaker_Speakers_SpeakerId];

GO

ALTER TABLE [ConferenceSpeaker] DROP CONSTRAINT [PK_ConferenceSpeaker];

GO

EXEC sp_rename N'ConferenceSpeaker', N'ConferenceSpeakers';

GO

EXEC sp_rename N'ConferenceSpeakers.IX_ConferenceSpeaker_ConferenceId', N'IX_ConferenceSpeakers_ConferenceId', N'INDEX';

GO

ALTER TABLE [ConferenceSpeakers] ADD CONSTRAINT [PK_ConferenceSpeakers] PRIMARY KEY ([SpeakerId], [ConferenceId]);

GO

ALTER TABLE [ConferenceSpeakers] ADD CONSTRAINT [FK_ConferenceSpeakers_Conferences_ConferenceId] FOREIGN KEY ([ConferenceId]) REFERENCES [Conferences] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [ConferenceSpeakers] ADD CONSTRAINT [FK_ConferenceSpeakers_Speakers_SpeakerId] FOREIGN KEY ([SpeakerId]) REFERENCES [Speakers] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170402071823_AddedContext', N'1.1.0-rtm-22752');

GO

ALTER TABLE [SpeakerTalk] DROP CONSTRAINT [FK_SpeakerTalk_Speakers_SpeakerId];

GO

ALTER TABLE [SpeakerTalk] DROP CONSTRAINT [FK_SpeakerTalk_Talks_TalkId];

GO

ALTER TABLE [SpeakerTalk] DROP CONSTRAINT [PK_SpeakerTalk];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Talks') AND [c].[name] = N'Location');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Talks] DROP COLUMN [Location];

GO

EXEC sp_rename N'SpeakerTalk', N'SpeakerTalks';

GO

EXEC sp_rename N'SpeakerTalks.IX_SpeakerTalk_TalkId', N'IX_SpeakerTalks_TalkId', N'INDEX';

GO

ALTER TABLE [SpeakerTalks] ADD CONSTRAINT [PK_SpeakerTalks] PRIMARY KEY ([SpeakerId], [TalkId]);

GO

ALTER TABLE [SpeakerTalks] ADD CONSTRAINT [FK_SpeakerTalks_Speakers_SpeakerId] FOREIGN KEY ([SpeakerId]) REFERENCES [Speakers] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [SpeakerTalks] ADD CONSTRAINT [FK_SpeakerTalks_Talks_TalkId] FOREIGN KEY ([TalkId]) REFERENCES [Talks] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170402075914_AddedRelationDBsetAndRemovedLocationOnTalk', N'1.1.0-rtm-22752');

GO

ALTER TABLE [Talks] ADD [Slug] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Speakers] ADD [Slug] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Conferences] ADD [Slug] nvarchar(max) NOT NULL DEFAULT N'';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170428032905_added-slug', N'1.1.0-rtm-22752');

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Talks') AND [c].[name] = N'Slug');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Talks] DROP COLUMN [Slug];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Speakers') AND [c].[name] = N'Slug');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Speakers] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Speakers] DROP COLUMN [Slug];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Conferences') AND [c].[name] = N'Slug');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Conferences] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Conferences] DROP COLUMN [Slug];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170430040429_removed-slug', N'1.1.0-rtm-22752');

GO

ALTER TABLE [Talks] DROP CONSTRAINT [FK_Talks_Conferences_ConferenceId];

GO

DROP TABLE [ConferenceSpeakers];

GO

DROP TABLE [SpeakerTalks];

GO

DROP TABLE [Conferences];

GO

DROP TABLE [Speakers];

GO

DROP INDEX [IX_Talks_ConferenceId] ON [Talks];

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Talks') AND [c].[name] = N'ConferenceId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Talks] DROP COLUMN [ConferenceId];

GO

CREATE TABLE [Tag] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [Name] nvarchar(max),
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TagTalks] (
    [TalkId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_TagTalks] PRIMARY KEY ([TalkId], [TagId]),
    CONSTRAINT [FK_TagTalks_Tag_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TagTalks_Talks_TalkId] FOREIGN KEY ([TalkId]) REFERENCES [Talks] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_TagTalks_TagId] ON [TagTalks] ([TagId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170508104055_RemoveSpeakerAndConference', N'1.1.0-rtm-22752');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170608045823_added-tag-talk-relationship', N'1.1.0-rtm-22752');

GO

