-- INSERT DATA
insert into contacts (birthdate, first_name, last_name)
values (now(), 'tim', 'corey'),
       (now(), 'saul', 'goodman');

-- CLEAR DATA
delete from contacts where id > 0;

-- GET DATA
select * from contacts;