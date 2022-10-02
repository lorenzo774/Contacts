-- INSERT DATA
insert into contacts (birthdate, first_name, last_name, phone, email)
values (now(), 'tim', 'corey', '+1-202-555-0100', 'tim@iamtimcorey.com'),
       (now(), 'saul', 'goodman', '+1-202-555-0153', 'saul@goodman.com');

-- CLEAR DATA
delete from contacts where email != '';

-- GET DATA
select * from contacts;