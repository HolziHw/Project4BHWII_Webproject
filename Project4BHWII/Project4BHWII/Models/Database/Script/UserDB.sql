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
    entryText text not null,
    uploadData varchar(21000),
    EntryTyp int not null,
    
    constraint id_PK primary key(id),
    foreign key (id_user) references users(id)
    );

	insert into entries values (1,1,"alkdsf","adflkajsdf",null,"1");

select * from users;