create database WebProjekt collate utf8_general_ci;
use WebProjekt;


create table users(
	id int not null auto_increment,
    firstname varchar(100) null,
    lastname varchar(100) not null,
    gender int not null,
    birthdate date null,
    username varchar(100) not null unique,
    password varchar(128),
    
    constraint id_PK primary key(id)
)engine=InnoDB;

drop table entries;

create table entries(
	id int not null auto_increment,
    id_name varchar(180) not null,
    titel varchar(180) not null,
    entryText text not null,
    uploadData varchar(21000),
    EntryTyp int not null,
    constraint id_PK primary key(id)
    );


select * from entries;