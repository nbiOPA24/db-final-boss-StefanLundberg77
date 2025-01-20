UPDATE [Product] SET StockBalance = 1 WHERE Id = 2;
DELETE [User] WHERE Username = 'sventenn';
select * from [Product];

drop table [User]

INSERT INTO [dbo].[Product] 
    ([ArtistName], [AlbumName], [RecordLabel], [ReleaseDate], [Genre], [Format], [Price], [PurchasePrice], [Used], [Condition], [StockBalance], [Description])
VALUES 
    ('Slayer', 'Hell Awaits', 'Metal Blade Records', 1985, 'Thrash Metal', 'Vinyl', 29.99, 15.00, 1, 'Good', 10, 'Second studio album by Slayer, a classic thrash metal release.');

INSERT INTO [dbo].[Campaign] ([Name], [Start], [End], [Description], [CampaignStatus], [DiscountId})
VALUES
('Oldies but goldies', '2025-01-01', '2025-02-01', '10% discount on records recorded before 1980', 1, 1);

INSERT INTO dbo.Discount (Value, Type)
VALUES
(10.00, '%')

-- FYLL PÅ MED BRA COOLA QUERYS ENNA!


--
INSERT INTO [dbo].[Product] 
    ([ArtistName], [AlbumName], [RecordLabel], [ReleaseDate], [Genre], [Format], [Price], [PurchasePrice], [Used], [Condition], [StockBalance], [Description])
VALUES
    ('Metallica', 'Master of Puppets', 'Elektra', 1986, 'Thrash Metal', 'Vinyl', 29.99, 15.00, 0, 'New', 50, 'Third studio album by Metallica.'),
    ('Slayer', 'Reign in Blood', 'Def Jam', 1986, 'Thrash Metal', 'CD', 25.99, 12.00, 1, 'Good', 1, 'Seminal thrash metal album.'),
    ('Iron Maiden', 'Powerslave', 'EMI', 1984, 'Heavy Metal', 'Vinyl', 30.99, 14.50, 0, 'New', 20, 'Classic album by Iron Maiden.'),
    ('Judas Priest', 'British Steel', 'Columbia', 1980, 'Heavy Metal', 'CD', 24.99, 13.00, 1, 'Very Good', 1, 'Groundbreaking heavy metal record.'),
    ('Megadeth', 'Rust in Peace', 'Capitol', 1990, 'Thrash Metal', 'Vinyl', 28.99, 16.00, 0, 'New', 30, 'Critically acclaimed Megadeth album.'),
    ('Black Sabbath', 'Paranoid', 'Vertigo', 1970, 'Doom Metal', 'Vinyl', 27.99, 15.00, 0, 'New', 25, 'Second studio album by Black Sabbath.'),
    ('AC/DC', 'Back in Black', 'Atlantic', 1980, 'Hard Rock', 'CD', 23.99, 12.00, 1, 'Good', 1, 'Legendary hard rock album.'),
    ('Pink Floyd', 'The Dark Side of the Moon', 'Harvest', 1973, 'Progressive Rock', 'Vinyl', 35.99, 18.00, 0, 'New', 40, 'Iconic Pink Floyd record.'),
    ('Led Zeppelin', 'Led Zeppelin IV', 'Atlantic', 1971, 'Hard Rock', 'Vinyl', 34.99, 17.50, 0, 'New', 35, 'Includes the hit "Stairway to Heaven".'),
    ('Queen', 'A Night at the Opera', 'EMI', 1975, 'Rock', 'CD', 22.99, 11.50, 1, 'Fair', 1, 'Features the classic "Bohemian Rhapsody".'),
    ('Nirvana', 'Nevermind', 'DGC', 1991, 'Grunge', 'CD', 20.99, 10.00, 1, 'Very Good', 1, 'Breakthrough album by Nirvana.'),
    ('Pearl Jam', 'Ten', 'Epic', 1991, 'Grunge', 'Vinyl', 29.99, 14.50, 0, 'New', 30, 'Debut album by Pearl Jam.'),
    ('Guns N Roses', 'Appetite for Destruction', 'Geffen', 1987, 'Hard Rock', 'CD', 26.99, 13.50, 1, 'Good', 1, 'Classic hard rock debut.'),
    ('Deep Purple', 'Machine Head', 'EMI', 1972, 'Hard Rock', 'Vinyl', 27.99, 15.00, 0, 'New', 20, 'Includes "Smoke on the Water".'),
    ('The Rolling Stones', 'Sticky Fingers', 'Rolling Stones Records', 1971, 'Rock', 'Vinyl', 31.99, 16.00, 0, 'New', 25, 'Features "Brown Sugar".'),
    ('The Beatles', 'Abbey Road', 'Apple', 1969, 'Rock', 'CD', 24.99, 12.50, 1, 'Fair', 1, 'Iconic album by The Beatles.'),
    ('David Bowie', 'The Rise and Fall of Ziggy Stardust', 'RCA', 1972, 'Glam Rock', 'Vinyl', 32.99, 18.00, 0, 'New', 20, 'Classic concept album.'),
    ('Black Flag', 'Damaged', 'SST', 1981, 'Punk', 'CD', 21.99, 11.00, 1, 'Good', 1, 'Hardcore punk classic.'),
    ('Misfits', 'Walk Among Us', 'Ruby', 1982, 'Punk', 'Vinyl', 28.99, 15.00, 0, 'New', 15, 'Seminal horror punk album.'),
    ('The Clash', 'London Calling', 'CBS', 1979, 'Punk', 'CD', 22.99, 11.50, 1, 'Very Good', 1, 'Classic punk rock double album.'),
    ('Joy Division', 'Unknown Pleasures', 'Factory', 1979, 'Post-Punk', 'Vinyl', 30.99, 16.00, 0, 'New', 20, 'Debut album by Joy Division.'),
    ('The Cure', 'Disintegration', 'Fiction', 1989, 'Gothic Rock', 'CD', 25.99, 13.00, 1, 'Good', 1, 'Critically acclaimed Cure album.'),
    ('Fleetwood Mac', 'Rumours', 'Warner Bros', 1977, 'Rock', 'Vinyl', 33.99, 17.50, 0, 'New', 35, 'One of the best-selling albums ever.'),
    ('Eagles', 'Hotel California', 'Asylum', 1976, 'Rock', 'Vinyl', 29.99, 14.50, 0, 'New', 30, 'Features "Hotel California".'),
    ('Tool', 'Lateralus', 'Volcano', 2001, 'Progressive Metal', 'Vinyl', 34.99, 18.00, 0, 'New', 20, 'Complex and heavy Tool album.'),
    ('Opeth', 'Blackwater Park', 'Music for Nations', 2001, 'Progressive Metal', 'CD', 27.99, 15.00, 1, 'Very Good', 1, 'Groundbreaking Opeth release.'),
    ('Pantera', 'Vulgar Display of Power', 'Atco', 1992, 'Groove Metal', 'CD', 25.99, 13.50, 1, 'Good', 1, 'Hard-hitting Pantera album.'),
    ('Alice in Chains', 'Dirt', 'Columbia', 1992, 'Grunge', 'Vinyl', 30.99, 16.00, 0, 'New', 20, 'Critically acclaimed grunge album.'),
    ('Soundgarden', 'Superunknown', 'A&M', 1994, 'Grunge', 'CD', 23.99, 12.00, 1, 'Fair', 1, 'Soundgarden’s magnum opus.'),
    ('Rage Against the Machine', 'Rage Against the Machine', 'Epic', 1992, 'Rap Metal', 'Vinyl', 32.99, 17.50, 0, 'New', 15, 'Explosive debut album.'),
    ('Slipknot', 'Iowa', 'Roadrunner', 2001, 'Nu Metal', 'CD', 25.99, 13.00, 1, 'Good', 1, 'Dark and heavy Slipknot album.'),
    ('Korn', 'Follow the Leader', 'Epic', 1998, 'Nu Metal', 'Vinyl', 31.99, 16.50, 0, 'New', 25, 'One of Korn’s biggest albums.'),
    ('System of a Down', 'Toxicity', 'American', 2001, 'Alternative Metal', 'Vinyl', 30.99, 15.00, 0, 'New', 20, 'Includes "Chop Suey!".'),
    ('Deftones', 'White Pony', 'Maverick', 2000, 'Alternative Metal', 'CD', 27.99, 14.50, 1, 'Very Good', 1, 'Atmospheric and heavy Deftones album.'),
    ('Nine Inch Nails', 'The Downward Spiral', 'Nothing', 1994, 'Industrial', 'Vinyl', 34.99, 17.50, 0, 'New', 20, 'Classic industrial rock album.'),
    ('Marilyn Manson', 'Antichrist Superstar', 'Interscope', 1996, 'Industrial', 'CD', 26.99, 13.50, 1, 'Fair', 1, 'Controversial and powerful album.'),
    ('Radiohead', 'OK Computer', 'Parlophone', 1997, 'Alternative Rock', 'Vinyl', 35.99, 18.00, 0, 'New', 30, 'Highly influential Radiohead album.'),
    ('Arcade Fire', 'Funeral', 'Merge', 2004, 'Indie Rock', 'CD', 24.99, 12.00, 1, 'Good', 1, 'Breakthrough album for Arcade Fire.'),
    ('Muse', 'Absolution', 'Warner Bros', 2003, 'Alternative Rock', 'Vinyl', 30.99, 16.00, 0, 'New', 25, 'Atmospheric and dynamic Muse album.'),
    ('The Smashing Pumpkins', 'Mellon Collie and the Infinite Sadness', 'Virgin', 1995, 'Alternative Rock', 'CD', 29.99, 14.50, 1, 'Good', 1, 'Ambitious double album.'),
    ('Foo Fighters', 'The Colour and the Shape', 'Roswell', 1997, 'Alternative Rock', 'Vinyl', 27.99, 13.00, 0, 'New', 20, 'Includes "Everlong".'),
    ('Weezer', 'Weezer (Blue Album)', 'Geffen', 1994, 'Alternative Rock', 'Vinyl', 28.99, 15.00, 0, 'New', 15, 'Iconic Weezer debut album.'),
    ('Green Day', 'Dookie', 'Reprise', 1994, 'Punk Rock', 'CD', 23.99, 11.50, 1, 'Very Good', 1, 'Breakthrough Green Day album.'),
    ('Blink-182', 'Enema of the State', 'MCA', 1999, 'Pop Punk', 'Vinyl', 29.99, 14.50, 0, 'New', 30, 'Includes "All the Small Things".'),
    ('My Chemical Romance', 'The Black Parade', 'Reprise', 2006, 'Emo', 'CD', 26.99, 13.00, 1, 'Fair', 1, 'Ambitious concept album.'),
    ('Paramore', 'Riot!', 'Fueled by Ramen', 2007, 'Pop Punk', 'Vinyl', 27.99, 14.50, 0, 'New', 25, 'Features "Misery Business".'),
    ('Miles Davis', 'Kind of Blue', 'Columbia', 1959, 'Jazz', 'Vinyl', 34.99, 18.00, 0, 'New', 40, 'Legendary cool jazz album.'),
    ('John Coltrane', 'A Love Supreme', 'Impulse!', 1965, 'Jazz', 'Vinyl', 32.99, 17.50, 0, 'New', 30, 'One of Coltranes finest works.'),
    ('Thelonious Monk', 'Monks Dream', 'Columbia', 1963, 'Jazz', 'CD', 25.99, 12.00, 1, 'Good', 1, 'Classic jazz album by Monk.'),
    ('Charlie Parker', 'Bird and Diz', 'Verve', 1952, 'Bebop', 'Vinyl', 28.99, 15.50, 0, 'New', 25, 'Collaboration with Dizzy Gillespie'),
    ('Duke Ellington', 'Ellington at Newport', 'Columbia', 1956, 'Big Band', 'CD', 24.99, 13.00, 1, 'Very Good', 1, 'Legendary live performance.'),
    ('Herbie Hancock', 'Head Hunters', 'Columbia', 1973, 'Jazz Fusion', 'Vinyl', 29.99, 14.50, 0, 'New', 35, 'Pioneering jazz-funk album.'),
    ('Dave Brubeck', 'Time Out', 'Columbia', 1959, 'Cool Jazz', 'Vinyl', 31.99, 16.00, 0, 'New', 30, 'Features the hit "Take Five".'),
    ('Bill Evans', 'Waltz for Debby', 'Riverside', 1961, 'Jazz', 'CD', 27.99, 14.00, 1, 'Good', 1, 'Iconic live recording.'),
    ('Chet Baker', 'Chet Baker Sings', 'Pacific Jazz', 1954, 'Vocal Jazz', 'Vinyl', 26.99, 13.50, 0, 'New', 20, 'Classic vocal jazz album.'),
    ('Charles Mingus', 'Mingus Ah Um', 'Columbia', 1959, 'Jazz', 'Vinyl', 33.99, 17.50, 0, 'New', 30, 'Highly influential jazz album.'),
    ('Sonny Rollins', 'Saxophone Colossus', 'Prestige', 1956, 'Jazz', 'CD', 28.99, 15.00, 1, 'Very Good', 1, 'Essential hard bop recording.'),
    ('Stan Getz', 'Getz/Gilberto', 'Verve', 1964, 'Bossa Nova', 'Vinyl', 29.99, 14.50, 0, 'New', 25, 'Includes the classic "The Girl from Ipanema".'),
    ('Art Blakey', 'Moanin', 'Blue Note', 1958, 'Hard Bop', 'Vinyl', 30.99, 15.50, 0, 'New', 20, 'Jazz Messengers signature album.'),
    ('Ella Fitzgerald', 'Ella and Louis', 'Verve', 1956, 'Vocal Jazz', 'Vinyl', 34.99, 18.00, 0, 'New', 40, 'Duets with Louis Armstrong.'),
    ('Louis Armstrong', 'What a Wonderful World', 'ABC', 1967, 'Traditional Jazz', 'CD', 23.99, 12.00, 1, 'Good', 1, 'Features the iconic title track.'),
    ('Pat Metheny', 'Bright Size Life', 'ECM', 1976, 'Jazz Fusion', 'Vinyl', 29.99, 14.50, 0, 'New', 30, 'Methenys groundbreaking debut.'),
    ('Weather Report', 'Heavy Weather', 'Columbia', 1977, 'Jazz Fusion', 'Vinyl', 32.99, 16.50, 0, 'New', 25, 'Features the hit "Birdland".'),
    ('Keith Jarrett', 'The Köln Concert', 'ECM', 1975, 'Jazz', 'CD', 27.99, 14.50, 1, 'Very Good', 1, 'Legendary solo piano performance.'),
    ('Diana Krall', 'The Look of Love', 'Verve', 2001, 'Vocal Jazz', 'Vinyl', 30.99, 15.50, 0, 'New', 35, 'Smooth and romantic jazz vocals.'),
    ('Norah Jones', 'Come Away with Me', 'Blue Note', 2002, 'Jazz', 'CD', 25.99, 13.00, 1, 'Good', 1, 'Breakthrough jazz-pop album.'),
    ('Wynton Marsalis', 'Black Codes (From the Underground)', 'Columbia', 1985, 'Jazz', 'Vinyl', 31.99, 16.50, 0, 'New', 30, 'Grammy-winning jazz album.'),
    ('Count Basie', 'April in Paris', 'Verve', 1957, 'Big Band', 'CD', 26.99, 14.00, 1, 'Good', 1, 'Swinging classic by Count Basie.'),
    ('Joe Henderson', 'Page One', 'Blue Note', 1963, 'Jazz', 'Vinyl', 30.99, 15.50, 0, 'New', 25, 'Includes the hit "Blue Bossa".'),
    ('Cannonball Adderley', 'Somethin Else', 'Blue Note', 1958, 'Hard Bop', 'CD', 27.99, 14.50, 1, 'Fair', 1, 'Features Miles Davis on trumpet.'),
    ('Oscar Peterson', 'Night Train', 'Verve', 1963, 'Jazz', 'Vinyl', 32.99, 16.50, 0, 'New', 20, 'Smooth piano jazz trio album.'),
    ('Nina Simone', 'Nina Simone Sings the Blues', 'RCA', 1967, 'Vocal Jazz', 'CD', 24.99, 12.50, 1, 'Good', 1, 'Powerful bluesy jazz vocals.'),
    ('Sarah Vaughan', 'Sarah Vaughan with Clifford Brown', 'EmArcy', 1954, 'Vocal Jazz', 'Vinyl', 33.99, 17.50, 0, 'New', 30, 'Classic jazz vocals with trumpet.'),
    ('Paul Desmond', 'Take Ten', 'RCA', 1963, 'Cool Jazz', 'Vinyl', 31.99, 16.00, 0, 'New', 25, 'Follows up on the success of "Take Five".'),
    ('Gerry Mulligan', 'Night Lights', 'Philips', 1963, 'Cool Jazz', 'CD', 25.99, 13.00, 1, 'Very Good', 1, 'Relaxed cool jazz vibes.'),
    ('Benny Goodman', 'The Famous 1938 Carnegie Hall Jazz Concert', 'Columbia', 1950, 'Swing', 'Vinyl', 29.99, 14.50, 0, 'New', 30, 'Historic live jazz performance.'),
    ('Chick Corea', 'Now He Sings, Now He Sobs', 'Solid State', 1968, 'Jazz', 'CD', 26.99, 13.50, 1, 'Fair', 1, 'Highly regarded piano trio album.'),
    ('Dexter Gordon', 'Go', 'Blue Note', 1962, 'Hard Bop', 'Vinyl', 30.99, 15.50, 0, 'New', 20, 'Features "Cheese Cake".'),
    ('Lee Morgan', 'The Sidewinder', 'Blue Note', 1964, 'Hard Bop', 'Vinyl', 32.99, 16.50, 0, 'New', 25, 'One of Morgans best albums.'),
    ('Ornette Coleman', 'The Shape of Jazz to Come', 'Atlantic', 1959, 'Free Jazz', 'CD', 28.99, 15.00, 1, 'Good', 1, 'Pioneering free jazz record.'),
    ('Max Roach', 'We Insist!', 'Candid', 1960, 'Jazz', 'Vinyl', 31.99, 16.00, 0, 'New', 20, 'Civil rights-themed jazz album.'),
    ('Mahavishnu Orchestra', 'The Inner Mounting Flame', 'Columbia', 1971, 'Jazz Fusion', 'Vinyl', 30.99, 15.50, 0, 'New', 25, 'John McLaughlin jazz-rock masterpiece.'),
    ('Pharoah Sanders', 'Karma', 'Impulse!', 1969, 'Spiritual Jazz', 'CD', 27.99, 14.50, 1, 'Good', 1, 'Features the epic "The Creator Has a Master Plan".'),
    ('Esperanza Spalding', 'Emilys D+Evolution', 'Concord', 2016, 'Jazz Fusion', 'Vinyl', 29.99, 14.50, 0, 'New', 35, 'Innovative jazz-pop fusion album.'),
    ('Roy Hargrove', 'Earfood', 'Emarcy', 2008, 'Jazz', 'CD', 26.99, 13.00, 1, 'Very Good', 1, 'Smooth and soulful jazz.'),
    ('Brad Mehldau', 'Largo', 'Warner Bros', 2002, 'Jazz', 'Vinyl', 33.99, 17.50, 0, 'New', 30, 'Modern jazz with a twist.');
--