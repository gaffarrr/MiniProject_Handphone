create database handphoneDB;

create table devices (
	id int not null primary key auto_increment,
    brand varchar(255),
    name varchar(255),
	os varchar(255),
    procie varchar(255),
    price bigint not null
);

create table device_has_nets(
	device_id int not null,
    net_id int not null
);

create table networks(
	id int not null,
    name varchar(255)
);
