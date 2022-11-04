-- Authors Table
create table if not exists authors(
name varchar(500) unique not null,
DOB date not null,
country varchar(500),
Primary key(name)
);


insert into authors(name, DOB,country) values ('J.K.Rowling', '1972-04-01', 'US');
insert into authors(name, DOB,country) values ('Zimmerman' , '1989-06-05', 'India');
insert into authors(name, DOB,country) values ('Douglas Adams' , '1999-10-05', 'Germany');
insert into authors(name, DOB,country) values ('Mary Grandpra' , '1987-06-07', 'Thailand');

select * from authors;

-- Books Table
create table if not exists books(
title varchar(500) unique not NULL,
DOP date,
language varchar(500),
Primary key(title)
);

insert into books(title, DOP,language) values ('Harry Potter 6', '2001-12-10', 'eng');
insert into books(title, DOP, language) values ('Harry Potter 5', '2007-10-20', 'eng');
insert into books(title, DOP, language) values ('Hitchhikers Guide 1', '2012-06-07', 'eng');
insert into books(title, DOP, language) values ('Hitchhikers Guide 5', '2005-11-23', 'eng');
insert into books(title, DOP, language) values ('History of Nearly Everything', '2020-12-10', 'eng');

select * from books;


-- Establishing Relationship
create table if not exists relation(	
name varchar(500) REFERENCES authors(name) ON DELETE CASCADE,
title  varchar(500) REFERENCES books(title) ON DELETE CASCADE,
PRIMARY KEY (name,title)
);

insert into relation(name, title) values ('J.K.Rowling', 'Harry Potter 6');
insert into relation(name, title) values ('J.K.Rowling', 'Harry Potter 5');
insert into relation(name, title) values ('Zimmerman', 'Hitchhikers Guide 1');
insert into relation(name, title) values ('Zimmerman', 'Hitchhikers Guide 5');
insert into relation(name, title) values ('Douglas Adams', 'History of Nearly Everything');
insert into relation(name, title) values ('Mary Grandpra', 'Harry Potter 6');

select * from relation;
