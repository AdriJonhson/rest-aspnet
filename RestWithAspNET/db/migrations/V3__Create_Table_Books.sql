CREATE TABLE IF NOT EXISTS  `books` (
    id bigint(20) not null auto_increment,
    title varchar(200) not null,
    author longtext not null,
    launch_date datetime not null,
    price decimal not null ,
    primary key (id)
)