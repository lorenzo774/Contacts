create table contacts
(
    email      varchar(255) not null
        primary key,
    first_name varchar(255) null,
    last_name  varchar(255) null,
    birthdate  datetime     null,
    phone      varchar(255) null,
    constraint email
        unique (email)
);
