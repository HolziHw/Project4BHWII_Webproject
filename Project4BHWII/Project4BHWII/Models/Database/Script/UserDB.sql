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

create table entries(
	id int not null auto_increment,
    id_user int not null,
    titel varchar(180) not null,
    entryText varchar(10000) not null,
    uploadData varchar(10000000),
    EntryTyp varchar(180) not null,
    
    constraint id_PK primary key(id),
    foreign key (id_user) references users(id)
    );



select * from users;