CREATE TABLE [dbo].[Notlar] (
    [NotId]              INT            NOT NULL,
    [Baslik]             NVARCHAR (100) NOT NULL,
    [Icerik]             NVARCHAR (MAX) NULL,
    [OlusturmaTarihi]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [SonDuzenlemeTarihi] DATETIME       NULL,
    [TamamlanmaDurumu]   BIT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([NotId] ASC)
);

