CREATE TABLE IF NOT EXISTS drivers(
	driver_Id serial PRIMARY KEY,
	driver_Ref varchar(24) NOT NULL,
	driver_Number varchar(3) NOT NULL,
	code varchar(5) NOT NULL,
	forename varchar(24) NOT NULL,
	surename varchar(24) NOT NULL,
	dob TIMESTAMP NOT NULL,
	natonality varchar(24) NOT NULL
);

CREATE TABLE IF NOT EXISTS circuits (
	circuit_Id serial primary key,
	circuit_Ref varchar(24) not null,
	circuit_Name varchar(64) not null,
	circuit_Location varchar(24) not null,
	circuit_Lat numeric(9,5) not null,
	circuit_Ing numeric(9,5) not null,
	circuit_Alt int not null
);

create table if not exists constructors(
	constructor_Id serial primary key,
	constructor_Ref Varchar(64) not null,
	constructor_Name varchar(64) not null,
	constructor_Nationality varchar(64) not null
);

create table if not exists statuses(
	status_Id serial primary key,
	status_Name varchar(24) not null
);

create table if not exists races(
	race_Id serial primary key,
	race_Year int not null,
	race_Round int not null,
	circuit_Id serial not null,
	race_Name varchar(64) not null,
	race_Date TimeStamp not null,
	race_Time Time not null,
	
	FOREIGN KEY (circuit_Id)
      REFERENCES circuits (circuit_Id)
);

create table if not exists results(
	result_Id serial primary key,
	race_Id serial not null,
	driver_Id serial not null,
	constructor_Id serial not null,
	result_Number int not null,
	result_Grid int not null,
	result_Position int not null,
	result_Position_Text varchar(2) not null,
	result_Position_Order int not null,
	result_Points numeric(4,2) not null,
	
	foreign key (race_Id)
		references races (race_Id),
	foreign key (driver_Id)
		references drivers (driver_Id),
	foreign key (constructor_Id)
		references constructors (constructor_Id)
);

create table if not exists constructor_results(
	constructor_result_Id serial primary key,
	race_Id serial not null,
	constructor_Id serial not null,
	constructor_result_Points int not null,
	status_Id serial not null,
	
	foreign key (race_Id)
		references races (race_Id),
	foreign key (constructor_Id)
		references constructors (constructor_Id),
	foreign key (status_Id)
		references statuses (status_Id)
);

create table if not exists constructor_standings(
	constructor_standing_Id serial primary key,
	race_Id serial not null,
	constructor_Id serial not null,
	constructor_standing_Points float not null,
	constructor_standing_Position int not null,
	constructor_standing_Position_Text varchar(2) not null,
	constructor_standing_Wins int not null,
	
	foreign key (race_Id)
		references races (race_Id),
	foreign key (constructor_Id)
		references constructors (constructor_Id)
);

create table if not exists driver_standings(
	driver_standing_Id serial primary key,
	race_Id serial not null,
	driver_Id serial not null,
	driver_standing_points int not null,
	driver_standing_position int not null,
	driver_standing_position_Text varchar(5) not null,
	driver_standing_wins int not null,
	
	foreign key (race_Id)
		references races (race_Id),
	foreign key (driver_Id)
		references drivers (driver_Id)
);

create table if not exists lap_times (
	race_Id serial,
	driver_Id serial,
	lap int,
	lap_time_position int not null,
	lap_time_time Time not null,
	primary Key(race_Id,driver_Id,lap)
);

create table if not exists qualifyings(
	qualifying_Id serial primary key,
	race_Id serial not null,
	driver_Id serial not null,
	constructor_Id serial not null,
	qualifying_position int not null,
	qualifying_q1 Time not null,
	qualifying_q2 Time not null,
	qualifying_q3 Time not null,
	
	foreign key (race_Id)
		references races (race_Id),
	foreign key (driver_Id)
		references drivers (driver_Id),
	foreign key (constructor_Id)
		references constructors (constructor_Id)
);

create table if not exists sprint_results(
	sprint_resultId serial primary key,
	race_Id serial not null,
	driver_Id serial not null,
	constructor_Id serial not null,
	sprint_result_number int not null,
	sprint_result_grid int not null,
	sprint_result_position int not null,
	sprint_result_position_text varchar(2) not null,
	sprint_result_position_order int not null,
	rsprint_result_points numeric(4,2) not null,
	
	foreign key (race_Id)
		references races (race_Id),
	foreign key (driver_Id)
		references drivers (driver_Id),
	foreign key (constructor_Id)
		references constructors (constructor_Id)
);

