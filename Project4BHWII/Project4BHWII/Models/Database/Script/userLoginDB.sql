create database userDBSite collate utf8_general_ci;
use userDBSite;


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

INSERT INTO users values (null, "David", "Holzhammer", 0, "2001-04-15","david4", sha2("adkfhj", 512));


select * from users;
