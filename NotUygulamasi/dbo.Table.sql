﻿CREATE TABLE [Not] (
    NotId INT PRIMARY KEY IDENTITY,
    Baslik NVARCHAR(100) NOT NULL,
    Icerik NVARCHAR(MAX) NULL,
    OlusturmaTarihi DATETIME NOT NULL DEFAULT GETDATE(),
    SonDuzenlemeTarihi DATETIME NULL,
    TamamlanmaDurumu BIT NOT NULL DEFAULT 0
);