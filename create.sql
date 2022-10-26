CREATE TABLE IF NOT EXISTS drivers(
	driverId serial PRIMARY KEY,
	driverRef varchar(24) NOT NULL,
	driverNumber varchar(3) NOT NULL,
	code varchar(5) NOT NULL,
	forename varchar(24) NOT NULL,
	surename varchar(24) NOT NULL,
	dob TIMESTAMP NOT NULL,
	natonality varchar(24) NOT NULL
);

CREATE TABLE IF NOT EXISTS circuits (
	circuitId serial primary key,
	circuitRef varchar(24) not null,
	circuitName varchar(64) not null,
	circuitLocation varchar(24) not null,
	circuitLat numeric(9,5) not null,
	circuitIng numeric(9,5) not null,
	circuitAlt int not null
);

create table if not exists constructors(
	constructorId serial primary key,
	constructorRef Varchar(24) not null,
	constructorName varchar(24) not null,
	constructorNationality varchar(24) not null
);

create table if not exists statuses(
	statusId serial primary key,
	statusName varchar(24) not null
);

create table if not exists races(
	raceId serial primary key,
	raceYear int not null,
	raceRound int not null,
	circuitId serial not null,
	raceName varchar(64) not null,
	raceDate TimeStamp not null,
	raceTime Time not null,
	
	FOREIGN KEY (circuitId)
      REFERENCES circuits (circuitId)
);

create table if not exists results(
	resultId serial primary key,
	raceId serial not null,
	driverId serial not null,
	constructorId serial not null,
	resultNumber int not null,
	resultGrid int not null,
	resultPosition int not null,
	resultPositionText varchar(2) not null,
	resultPositionOrder int not null,
	resultPoints int not null,
	
	foreign key (raceId)
		references races (raceId),
	foreign key (driverId)
		references drivers (driverId),
	foreign key (constructorId)
		references constructors (constructorId)
);

create table if not exists constructor_results(
	constructor_resultId serial primary key,
	raceId serial not null,
	constructorId serial not null,
	constructor_resultPoints int not null,
	statusId serial not null,
	
	foreign key (raceId)
		references races (raceId),
	foreign key (constructorId)
		references constructors (constructorId),
	foreign key (statusId)
		references statuses (statusId)
);

create table if not exists constructor_standings(
	constructor_standingId serial primary key,
	raceId serial not null,
	constructorId serial not null,
	constructor_standingPoints int not null,
	constructor_standingPosition int not null,
	constructor_standingPositionText varchar(2) not null,
	constructor_standingWins int not null,
	
	foreign key (raceId)
		references races (raceId),
	foreign key (constructorId)
		references constructors (constructorId)
);

create table if not exists driver_standings(
	driver_standingId serial primary key,
	raceId serial not null,
	driverId serial not null,
	driver_standing_points int not null,
	driver_standing_position int not null,
	driver_standing_positionText varchar(2) not null,
	driver_standing_wins int not null,
	
	foreign key (raceId)
		references races (raceId),
	foreign key (driverId)
		references drivers (driverId)
);

create table if not exists lap_times (
	raceId serial,
	driverId serial,
	lap int,
	lap_time_position int not null,
	lap_time_time Time not null,
	primary Key(raceId,driverId,lap)
);

create table if not exists qualifyings(
	qualifyingId serial primary key,
	raceId serial not null,
	driverId serial not null,
	constructorId serial not null,
	qualifying_position int not null,
	qualifying_q1 Time not null,
	qualifying_q2 Time not null,
	qualifying_q3 Time not null,
	
	foreign key (raceId)
		references races (raceId),
	foreign key (driverId)
		references drivers (driverId),
	foreign key (constructorId)
		references constructors (constructorId)
);

create table if not exists sprint_results(
	sprint_resultId serial primary key,
	raceId serial not null,
	driverId serial not null,
	constructorId serial not null,
	sprint_result_number int not null,
	sprint_result_grid int not null,
	sprint_result_position int not null,
	sprint_result_position_text varchar(2) not null,
	sprint_result_position_order int not null,
	rsprint_result_points int not null,
	
	foreign key (raceId)
		references races (raceId),
	foreign key (driverId)
		references drivers (driverId),
	foreign key (constructorId)
		references constructors (constructorId)
);

