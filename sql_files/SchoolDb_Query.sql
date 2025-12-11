USE SchoolDb

INSERT INTO Departments (DepartmentName) VALUES
('School Administrations'),
('Astro-Engineering'),
('Xenolinguistics & Cosmic Arts'),
('Exoplanetary Sciences');

INSERT INTO Roles (RoleName) VALUES
('Principal'),
('Administrator'),
('Teacher');

INSERT INTO Employees (FirstName, LastName, YearsEmployed, Salary, DepartmentId, RoleId) VALUES
('Astra', 'Solarius', 15, 120000, 1, 1), -- Principal
('Lyra', 'Cometwell', 6, 65000, 1, 2),   -- Admin
('Dax', 'Nebulon', 4, 63000, 1, 2),      -- Admin

-- Astro-Engineering Teachers
('Nova', 'Starforge', 3, 54000, 2, 3),
('Quint', 'Ionflare', 5, 56000, 2, 3),

-- Xenolinguistics & Cosmic Arts Teachers
('Elara', 'Moonscribe', 7, 58000, 3, 3),
('Zen', 'Hyperquill', 2, 52000, 3, 3),

-- Exoplanetary Sciences Teachers
('Rhea', 'Stellarwind', 6, 60000, 4, 3),
('Kade', 'Solarcrest', 4, 55000, 4, 3),
('Vega', 'Astrostride', 3, 53000, 4, 3);

INSERT INTO Classes (ClassName, EmployeeId) VALUES
-- Astro-Engineering classes
('Quantum Mechanics Cadets', 4),
('Warp Drive Innovators', 5),

-- Xenolinguistics & Cosmic Arts classes 
('Galactic Storyweavers', 6),
('Cosmic Symbol Decoders', 7),

-- Exoplanetary Science classes
('Exoplanet Explorers', 8),
('Astrobiology Field Scouts', 9),
('Gravitational Analysts', 10);

INSERT INTO Courses (CourseName, IsActive) VALUES
('Plasma Reactor Design', 0),
('Warp Drive Systems', 1),
('Anti-Gravity Engineering', 0),
('Starship Structural Integrity', 1),
('AI Navigation Algorithms', 0),

('Stellar Poetry', 1),
('Alien Symbolism', 0),
('Cosmic Calligraphy', 0),
('Interstellar Diplomacy', 0),
('Galactic Performance Arts', 1),

('Planetary Atmosphere Analysis', 1),
('Exoplanet Mapping', 1),
('Alien Ecosystem Studies', 0),
('Cosmic Chemistry', 0),
('Star Formation Theory', 0);

INSERT INTO ClassCourse VALUES
-- Assign 5 courses to Astro-Engineering classes
(1,1),(1,2),(1,3),(1,4),(1,5),
(2,1),(2,2),(2,3),(2,4),(2,5),

-- Assign 5 courses to Xenolinguistics & Cosmic Arts classes 
(3,6),(3,7),(3,8),(3,9),(3,10),
(4,6),(4,7),(4,8),(4,9),(4,10),

-- Assign 5 courses to Exoplanetary Science classes
(5,11),(5,12),(5,13),(5,14),(5,15),
(6,11),(6,12),(6,13),(6,14),(6,15),
(7,11),(7,12),(7,13),(7,14),(7,15);

INSERT INTO Students (FirstName, LastName, PersonalNumber, ClassId) VALUES
-- Quantum Mechanics Cadets
('Astra', 'Starborn', '20930112-4821', 1),
('Zeph', 'Quasarion', '20940719-1144', 1),
('Liorin', 'Cryostorm', '20981103-9921', 1),
('Vexa', 'Lumidrift', '20960222-6634', 1),
('Orin', 'Nebulight', NULL, 1),
('Cyra', 'Astragale', '20920914-8820', 1),
('Juno', 'Plasmarise', '20951203-1194', 1),
('Caelix', 'Starweave', NULL, 1),
('Sera', 'Ionflare', '20970529-7221', 1),
('Taryn', 'Photoncrest', '20981014-7732', 1),
('Nexis', 'Voidstrand', NULL, 1),
('Elara', 'Solarcrest', '20990711-1822', 1),
('Kaelis', 'Nebulon', '20930822-7333', 1),
('Rivaan', 'Hyperline', NULL, 1),
('Myra', 'Aetherborn', '20910504-4421', 1),
('Solin', 'Galaxen', '20971218-2211', 1),
('Ereon', 'Starforge', NULL, 1),
('Nyra', 'Lightwell', '20980430-9922', 1),
('Daxen', 'Quantumrise', '20950321-2832', 1),
('Veira', 'Novahelm', NULL, 1),

-- Warp Drive Innovators 
('Zyra', 'Fluxborn', '20920615-3344', 2),
('Torin', 'Heliostride', '20951107-9332', 2),
('Isara', 'Nebulace', '20970930-5521', 2),
('Kelrix', 'Voidcaster', NULL, 2),
('Siona', 'Astravale', '20931212-2210', 2),
('Varo', 'Pulsewind', '20910428-1144', 2),
('Nira', 'Cometstrike', NULL, 2),
('Olen', 'Warpstride', '20980503-3343', 2),
('Cyrene', 'Ionwave', '20990530-7832', 2),
('Jaxen', 'Photonlash', NULL, 2),
('Vellin', 'Starflare', '20930727-5599', 2),
('Mirae', 'Novaecho', NULL, 2),
('Aerin', 'Lightweft', '20960114-8344', 2),
('Rhyss', 'Astropulse', '20940122-5521', 2),
('Tayen', 'Gravimark', NULL, 2),
('Sorix', 'Hypercrest', '20910908-4901', 2),
('Lysa', 'Stellavine', '20991010-7711', 2),
('Cairn', 'Fluxspire', NULL, 2),
('Zalen', 'Cometrise', '20981009-7721', 2),
('Elyss', 'Solarine', NULL, 2),

-- Galactic Storyweavers
('Ilyra', 'Dreamweft', '20970524-2199', 3),
('Serin', 'Mythflare', '20950807-3144', 3),
('Kaela', 'Starquill', NULL, 3),
('Vorian', 'Hyperwhisp', '20921219-7721', 3),
('Nirae', 'Lumithread', NULL, 3),
('Jex', 'Starglint', '20981001-2622', 3),
('Astrae', 'Cosmofable', '20930923-1144', 3),
('Renox', 'Loreweaver', NULL, 3),
('Myrea', 'Echoflare', '20990322-8301', 3),
('Soril', 'Talecrest', NULL, 3),
('Vayla', 'Galestory', '20950605-4421', 3),
('Therin', 'Nebulore', '20960412-9911', 3),
('Elyra', 'Fluxscribe', NULL, 3),
('Cyril', 'Hyperink', '20990209-2821', 3),
('Nolyn', 'Starmuse', NULL, 3),
('Maelis', 'Quillborn', '20941018-7322', 3),
('Orya', 'Songstrike', '20950627-4411', 3),
('Zehrin', 'Pulseverse', NULL, 3),
('Talya', 'Mythrise', '20971114-5523', 3),
('Aeron', 'Stellatale', NULL, 3),

-- Cosmic Symbol Decoders
('Kyra', 'Glyphflare', '20961021-5521', 4),
('Vorix', 'Runehelm', '20940213-7711', 4),
('Silin', 'Starcipher', NULL, 4),
('Arien', 'Cosmocode', '20981129-9843', 4),
('Nexa', 'Quantumglyph', NULL, 4),
('Lorik', 'Symbolight', '20920802-4421', 4),
('Virae', 'Astrogram', '20970109-1132', 4),
('Hexin', 'Voidetch', NULL, 4),
('Salea', 'Hyperglyph', '20940325-7721', 4),
('Korrin', 'Glyphstrand', NULL, 4),
('Tyria', 'Stellacode', '20980908-3312', 4),
('Rhel', 'Orbitmark', '20991003-5521', 4),
('Irielle', 'Nebucode', NULL, 4),
('Caven', 'Runecrest', '20960720-4401', 4),
('Selix', 'Lightcipher', NULL, 4),
('Mira', 'Symbolsong', '20930813-1134', 4),
('Zorin', 'Glyphcast', '20960222-2210', 4),
('Elira', 'Hyperetch', NULL, 4),
('Sorven', 'Cosmocarve', '20921218-8822', 4),
('Talis', 'Voidink', NULL, 4),

-- Exoplanet Explorers
('Rava', 'Startrail', '20941004-2241', 5),
('Kyrin', 'Planetrise', '20990920-7723', 5),
('Zalix', 'Dustwalker', NULL, 5),
('Orena', 'Orbithaven', '20970606-5544', 5),
('Mavin', 'Astrostide', '20981104-3321', 5),
('Tyrel', 'Exotrail', NULL, 5),
('Syla', 'Worldweft', '20920712-7712', 5),
('Varon', 'Nodewander', NULL, 5),
('Eris', 'Planisphere', '20960328-5521', 5),
('Naelis', 'Terrainlight', '20910516-2299', 5),
('Calen', 'Orbimark', NULL, 5),
('Myra', 'Pathfinder', '20990110-8811', 5),
('Rexil', 'Frontierborn', NULL, 5),
('Elyssia', 'Stoneridge', '20960514-7712', 5),
('Toriel', 'Atmoswalk', NULL, 5),
('Varyn', 'Dustvec', '20980702-5521', 5),
('Neris', 'Worldcrest', '20970709-3344', 5),
('Solin', 'Exocrest', NULL, 5),
('Jaira', 'Skystride', '20980921-5533', 5),
('Kellis', 'Orbifold', NULL, 5),

-- Astrobiology Field Scouts
('Liora', 'Bioflare', '20931207-7711', 6),
('Theros', 'Cellborn', '20991129-5521', 6),
('Vynna', 'Sporeweft', NULL, 6),
('Orren', 'Microstide', '20960611-3354', 6),
('Xyra', 'Genecast', '20980927-2288', 6),
('Marek', 'Lifecrest', NULL, 6),
('Sirella', 'Bioglow', '20971014-4401', 6),
('Norik', 'Spliceborn', NULL, 6),
('Vexa', 'Cytoshade', '20950902-7712', 6),
('Eland', 'Nexoplasma', NULL, 6),
('Kyrel', 'Genomehelm', '20951218-6612', 6),
('Nyssa', 'Bioforge', '20931220-5534', 6),
('Rhes', 'Celltrace', NULL, 6),
('Oryss', 'Sporecrest', '20980428-2292', 6),
('Veyra', 'Pathogenix', NULL, 6),
('Corin', 'Bioform', '20910130-4402', 6),
('Zalya', 'Helixmark', '20920708-8892', 6),
('Tovin', 'Cytorise', NULL, 6),
('Aerith', 'Microflare', '20930615-7711', 6),
('Jarik', 'Genweave', NULL, 6),

-- Gravitational Analysts
('Kira', 'Gravityborn', '20950618-7112', 7),
('Varyn', 'Orbipulse', '20980824-5521', 7),
('Stelan', 'Massflare', NULL, 7),
('Ryssa', 'Wellstrike', '20910203-5521', 7),
('Torin', 'Gravimark', '20970722-7721', 7),
('Eluna', 'Orbitshade', NULL, 7),
('Neros', 'Pullcrest', '20930229-1141', 7),
('Selya', 'Shiftline', NULL, 7),
('Kaer', 'Massquake', '20991111-6622', 7),
('Vexra', 'Forceria', NULL, 7),
('Talon', 'Singularis', '20931209-4411', 7),
('Iryll', 'Orbitflare', '20960730-7732', 7),
('Cylen', 'Tideform', NULL, 7),
('Otris', 'Massweft', '20940814-2210', 7),
('Nyelle', 'Gravitastra', NULL, 7),
('Seren', 'Pullwave', '20921027-9912', 7),
('Orvas', 'Luminmass', '20950819-4433', 7),
('Tyra', 'Shiftcrest', NULL, 7),
('Zaren', 'Starpull', '20900210-7744', 7),
('Elix', 'Forcestone', NULL, 7);