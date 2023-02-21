

drop database if exists gemuese_laden;
create database gemuese_laden;
use gemuese_laden;


drop table if exists kunde;
create table kunde
	(kd_id integer primary key auto_increment,
	kd_name varchar(100),
	kd_nach_name varchar(150),
	kd_pswd varchar(150),
	kd_email varchar(150) unique key);
	
	
drop table if exists mitarbeiter;
create table mitarbeiter
	(mi_id int primary key auto_increment,
	mi_name varchar(100),
	mi_nach_name varchar(150),
	mi_pswd varchar(150),
	mi_email varchar(150) unique key);
	
drop table if exists kathegorie;
create table kathegorie
	(kat_id int primary key auto_increment,
	kat_name varchar(100));


drop table if exists artikel;
create table artikel
	(art_id int primary key auto_increment,
	art_name varchar(100),
	besch varchar(100),
	kat_id int,
	foreign key (kat_id)
	references kathegorie (kat_id),
	einheit enum('kg', 'g', 'stk'),
	preis decimal);
	

	
drop table if exists lager;
create table lager
	(lag_id int primary key auto_increment,
	lag_name varchar(100),
	kapazitaet int not  null);


drop table if exists bestand;
create table bestand
	(best_id int primary key auto_increment,
	lag_id int,
	foreign key (lag_id)
	references lager (lag_id) 
	on delete cascade,
	art_id int, 
	foreign key (art_id)
	references artikel (art_id));


drop table if exists bestellung;
create table bestellung
	(be_id int primary key auto_increment,
	kd_id int,
	foreign key (kd_id)
	references kunde (kd_id)
	on delete cascade,
	lag_id int,
	foreign key (lag_id)
	references lager (lag_id),
	be_datum timestamp,
	be_status enum('im Warenkorb', 'bestellt', 'bezahlt', 'verpackt', 'versendet', 'storniert'));	
	
	
drop table if exists position;
create table position
	(pos_id int primary key auto_increment,
	be_id int not NULL,
	foreign key (be_id)
	references bestellung (be_id)
	on delete cascade,
	art_id int,
	foreign key (art_id)
	references artikel (art_id));
	
	
			----------------------------------------------------------------------------------------------
	
	
	
	//c#
		select * from v_artikel;
	
	
drop view if exists v_artikel;
create view v_artikel as
select art.art_name as name, kat.kat_name, art.besch as hinweis, art.einheit as einheit, art.preis as preis
	from artikel as art
	inner join kathegorie as kat
	on art.kat_id = kat.kat_id
	order by kat.kat_name;
	
	
	
	// c# query
		-select * from v_aktueller_bestand where lag_name = '{0}';
		-select * from v_aktueller_bestand where art_name = '{0}';
	
drop view if exists v_aktueller_bestand;
create view v_aktueller_bestand as
select lager.lag_name, art.art_name, count(art.art_name) as anzahl 
	from bestand as best
	inner join artikel as art
	on best.art_id = art.art_id
	inner join lager
	on best.lag_id = lager.lag_id
	group by art.art_name, lager.lag_name 
	order by lager.lag_name;
	
	
	
	
	// c# query
		-select * from v_aktuelle_be where status = '{0}';
		-select * from v_aktuelle_be where kd_name = '{0}';
		-select * from v_aktuelle_be where kd_name = '{0}' and status = '{1}';
	
	
drop view if exists v_aktuelle_be;
create view v_aktuelle_be as
select kd.kd_name, be.be_id, be.be_status as status, be.be_datum  
	from position as pos
	inner join bestellung as be
	on pos.be_id = be.be_id
	inner join kunde as kd
	on be.kd_id = kd.kd_id
	group by kd.kd_id
	order by be.be_id, kd.kd_name;
	

	
	
			-------------------------------------------------------------------------------------
	//c#
		call p_neu_kd({0}, {1}, {2}, {3});
	
drop procedure if exists p_neu_kd;
delimiter $$
create procedure p_neu_kd(neu_kd_name varchar(100), neu_kd_nach_name varchar(150), neu_kd_pswd varchar(150), neu_kd_email varchar(150))
begin
	insert into kunde (kd_name, kd_nach_name, kd_pswd, kd_email)
		values (neu_kd_name, neu_kd_nach_name, SHA1(neu_kd_pswd), neu_kd_email);
end $$
delimiter ;


	//c#
		call p_neu_mi({0}, {1}, {2}, {3});

drop procedure if exists p_neu_mi;
delimiter $$
create procedure p_neu_mi(neu_mi_name varchar(100), neu_mi_nach_name varchar(150), neu_mi_pswd varchar(150), neu_mi_email varchar(150))
begin
	insert into mitarbeiter (mi_name, mi_nach_name, mi_pswd, mi_email)
		values (neu_mi_name, neu_mi_nach_name, SHA1(neu_mi_pswd), neu_mi_email);
end $$
delimiter ;

	//c#
		call p_neu_lag({0}, {1});

drop procedure if exists p_neu_lag;
delimiter $$
create procedure p_neu_lag(neu_lag_name varchar(100), neu_kapazitaet int)
begin
	insert into lager(lag_name, kapazitaet)
		values (neu_lag_name, neu_kapazitaet);
end $$
delimiter ;
	
	//c#
		call p_bestand_hinzu({0}, {1}, {2});
	
	
drop procedure if exists p_bestand_hinzu;
delimiter $$
create procedure  p_bestand_hinzu(p_lag_id int, p_art_id int, anzahl int)
begin
	declare x int;
	set x = 0;
	loop_label: loop
		if x >= anzahl  then
			leave loop_label;
		else
			set x = x +1;
			insert into bestand (lag_id, art_id)
				values (p_lag_id, p_art_id);
				iterate loop_label;
		end if;
	end loop;
end $$
delimiter ;	


	//c#
		call p_neue_best({0}, {1});


drop procedure if exists p_neue_best;
delimiter $$
create procedure p_neue_best(p_kd_id int, p_lag_id int)
begin
	insert into bestellung (kd_id, lag_id, be_Datum, be_status)
		values (p_kd_id, p_lag_id, now(), 1);
end $$
delimiter ;


	//c#
		call p_neue_pos({0}, {1}, {2});

drop procedure if exists p_neue_pos;
delimiter $$
create procedure p_neue_pos(pos_be_id int, pos_art_id int, anzahl int)
begin
	declare x int;
	set x = 0;
	loop_label: loop
		if x >= anzahl  then
			leave loop_label;
		else
			set x = x +1;
			insert into position (be_id, art_id)
				values (pos_be_id, pos_art_id);
				iterate loop_label;
		end if;
	end loop;
end $$
delimiter ;



	//wenn der bestell_status vom mitarbeiter auf 'verpackt' gesetzt wird, wird seine bestellung aus dem bestand entfernt
		-call p_status({0}, {0});


drop procedure if exists p_status;
delimiter $$
create procedure p_status(p_be_id int, p_be_status int)
begin
	declare x int;
	select count(art_id) into x from position where p_be_id = be_id;
	if p_be_status = 4 then
		delete from bestand 
			where (select lag_id from bestellung where p_be_id = be_id) = lag_id 
				and (select art_id from bestellung where p_be_id = be_id) = art_id
				limit x;
	end if;
	update bestellung 
	set be_status = p_be_status 
	where be_id = p_be_id;
	
end $$
delimiter ;




--------------------------------------------------------------------------------------------------------------------



Test daten


call p_neu_kd('Olaf', 'Scholz', '123456', 'olaf@mail.com');
call p_neu_kd('Olec', 'Scholz', '654321', 'olec@mail.com');
call p_neu_kd('Ulf', 'Rad', '123456', 'ulf@mail.com');
call p_neu_kd('Donald', 'Müller', 'password', 'donald@mail.com');
call p_neu_kd('Peter', 'Scholz', '1234', 'peter@mail.com');


call p_neu_mi('Olga', 'Schmidt', '123456', 'olga@mail.com');
call p_neu_mi('Tom', 'Schmidts', '123456', 'tom@mail.com');
call p_neu_mi('Ofal', 'Scholz', '123456', 'olaf@mail.com');


insert into kathegorie(kat_name)
	values('Gemuese');
insert into kathegorie(kat_name)
	values('Obst');
insert into kathegorie(kat_name)
	values('Süßwaren');
	

	

insert into artikel(art_name, besch, kat_id, einheit, preis)
	values('Gurke', 'Diese gut', 1, 3, 1);
insert into artikel(art_name, besch, kat_id, einheit, preis)
	values('Tomate', 'Diese gut', 1, 1, 3);
insert into artikel(art_name, besch, kat_id, einheit, preis)
	values('Paprika', 'Diese gut', 1, 1, 3);
insert into artikel(art_name, besch, kat_id, einheit, preis)
	values('Apfel', 'Diese gut', 2, 1, 3);
insert into artikel(art_name, besch, kat_id, einheit, preis)
	values('Birne', 'Diese gut', 2, 1, 6);
insert into artikel(art_name, besch, kat_id, einheit, preis)
	values('Lutscher', 'Diese gut', 3, 3, 5);
	

insert into lager(lag_name, kapazitaet)
	values('West', 100);
insert into lager(lag_name, kapazitaet)
	values('Ost', 400);
	
	
insert into bestand(lag_id, art_id)
	values (1,1);
	
	
call p_neu_lag('Süd', 50);

call p_bestand_hinzu(1, 1, 10);
call p_bestand_hinzu(1, 2, 20);
call p_bestand_hinzu(1, 3, 5);
call p_bestand_hinzu(3, 6, 40);
call p_bestand_hinzu(2, 1, 100);
call p_bestand_hinzu(1, 2, 3);



call p_neue_best(1, 1);
call p_neue_pos(1, 1, 3);
call p_neue_pos(1, 2, 4);
call p_neue_pos(1, 3, 2);




call p_neue_best(2, 1);
call p_neue_pos(2, 1, 3);
call p_neue_pos(2, 2, 4);
call p_neue_pos(2, 3, 2);


call p_neue_best(3, 2);
call p_neue_pos(3, 1, 3);


call p_neue_best(4, 3);
call p_neue_pos(4, 6, 50);



call p_neue_best(3, 2);
call p_neue_pos({0}, {1});
call p_neue_pos({0}, {1});
call p_neue_pos({0}, {1});
call p_neue_pos({0}, {1});


call p_neue_best(4, 3);
call p_neue_pos({0}, {1});
