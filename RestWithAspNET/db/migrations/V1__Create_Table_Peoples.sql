CREATE TABLE IF NOT EXISTS  `peoples` (
    id bigint(20) not null auto_increment,
    first_name varchar(100) not null,
    last_name varchar(100) not null,
    gender varchar(6),
    address varchar(200),
    primary key (id)
)