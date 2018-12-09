-- various

select * from types;
select * from sectors;
select * from products;
select * from prod_sectors;
SELECT * FROM movements;

select distinct p.pro_name, s.hall
  from products p
  inner join prod_sectors ps on p.id = ps.id_product 
  inner join sectors 	  s  on s.id = ps.id_sector
  ;
 
 
select id from products where id = 44;

select s.sec_name, s.hall as sector_hall , s.id
from products p 
inner join prod_sectors ps on p.id = ps.id_product
inner join sectors s on s.id = ps.id_sector
where p.id = 44 ;



SELECT s.sec_name, s.hall AS sector_hall, ps.stock FROM products p 
INNER JOIN prod_sectors ps on p.id = ps.id_product INNER JOIN sectors s on s.id = ps.id_sector WHERE p.id = 44;

truncate table sectors;
truncate table types;
truncate table products;
truncate table prod_sectors;



INSERT INTO movements (id, `id_product`, id_sector, count, operation, `mov_date`)
VALUES (NULL, 86, 54, 20, "B","22/1/2018");


UPDATE movements SET id_product = 99 WHERE id = 7;
UPDATE movements SET id_sector = 58 WHERE id = 7;



-----------------------------------------------------------------------------------------------------------
-- general
  -- reset id column
  --ALTER TABLE <table> ALTER COLUMN ID COUNTER(1, 1);

-----------------------------------------------------------------------------------------------------------
-- sectors
  --select * from sectors;

  truncate table sectors;
  insert into sectors (id, sec_name, hall)
  values(
    (null, "A", 1),
    (null, "B", 2),
    (null, "C", 3),
    (null, "D", 4),
    (null, "E", 5),
    (null, "F", 6)
  );


-----------------------------------------------------------------------------------------------------------
-- types
  --select * from types;

  truncate table types;
  insert into types (id, typ_name, codint)
  values(
    (null, "A", "AAAA-01/A1"),
    (null, "B", "BBBB-02/B2")
  );

-----------------------------------------------------------------------------------------------------------
-- products
  SELECT * FROM products ;

  truncate table products;
  insert into products (id, id_type, pro_name, stock, state) 
  values (
    (null, (select id from types limit 0,1), 'a', 0, 'A'),
    (null, (select id from types limit 0,1), 'b', 0, 'A'),
    (null, (select id from types limit 0,1), 'c', 0, 'A'),
    (null, (select id from types limit 1,1), 'd', 0, 'A'),
    (null, (select id from types limit 1,1), 'e', 0, 'A'),
    (null, (select id from types limit 1,1), 'f', 0, 'A')
  );

  --ALTER TABLE products ALTER COLUMN ID COUNTER(1, 1)
  --DELETE FROM products WHERE id = 4 ;

-----------------------------------------------------------------------------------------------------------
-- product_sectors
  select * from prod_sectors;

  truncate table prod_sectors;
  insert into prod_sectors (id, id_product, id_sector, stock) 
  values (
    (null, (select id from products limit 0,1), (select id from sectors limit 0,1), 10),
    (null, (select id from products limit 0,1), (select id from sectors limit 0,1), 20),
    (null, (select id from products limit 0,1), (select id from sectors limit 0,1), 30),
    
    (null, (select id from products limit 1,1), (select id from sectors limit 1,1), 20),
    (null, (select id from products limit 1,1), (select id from sectors limit 1,1), 20),
    (null, (select id from products limit 1,1), (select id from sectors limit 1,1), 20),
    
    (null, (select id from products limit 2,1), (select id from sectors limit 2,1), 20),
    (null, (select id from products limit 2,1), (select id from sectors limit 2,1), 20),
    (null, (select id from products limit 2,1), (select id from sectors limit 2,1), 20),
    
    (null, (select id from products limit 3,1), (select id from sectors limit 3,1), 20),
    (null, (select id from products limit 3,1), (select id from sectors limit 3,1), 20),
    (null, (select id from products limit 3,1), (select id from sectors limit 3,1), 20),
    
    (null, (select id from products limit 4,1), (select id from sectors limit 4,1), 20),
    (null, (select id from products limit 4,1), (select id from sectors limit 4,1), 20),
    (null, (select id from products limit 4,1), (select id from sectors limit 4,1), 20),
    
    (null, (select id from products limit 5,1), (select id from sectors limit 5,1), 20),
    (null, (select id from products limit 5,1), (select id from sectors limit 5,1), 20),
    (null, (select id from products limit 5,1), (select id from sectors limit 5,1), 20)
  );


-----------------------------------------------------------------------------------------------------------
-- movements
select * from movements;

  truncate table movements;
  insert into movements (id, id_product, id_sector, stock) 
  values (
    (null, (select id from products limit 0,1), (select id from sectors limit 0,1), 10),
    (null, (select id from products limit 0,1), (select id from sectors limit 0,1), 20),
    (null, (select id from products limit 0,1), (select id from sectors limit 0,1), 30),
    
    (null, (select id from products limit 1,1), (select id from sectors limit 1,1), 20),
    (null, (select id from products limit 1,1), (select id from sectors limit 1,1), 20),
    (null, (select id from products limit 1,1), (select id from sectors limit 1,1), 20),
    
    (null, (select id from products limit 2,1), (select id from sectors limit 2,1), 20),
    (null, (select id from products limit 2,1), (select id from sectors limit 2,1), 20),
    (null, (select id from products limit 2,1), (select id from sectors limit 2,1), 20),
    
    (null, (select id from products limit 3,1), (select id from sectors limit 3,1), 20),
    (null, (select id from products limit 3,1), (select id from sectors limit 3,1), 20),
    (null, (select id from products limit 3,1), (select id from sectors limit 3,1), 20),
    
    (null, (select id from products limit 4,1), (select id from sectors limit 4,1), 20),
    (null, (select id from products limit 4,1), (select id from sectors limit 4,1), 20),
    (null, (select id from products limit 4,1), (select id from sectors limit 4,1), 20),
    
    (null, (select id from products limit 5,1), (select id from sectors limit 5,1), 20),
    (null, (select id from products limit 5,1), (select id from sectors limit 5,1), 20),
    (null, (select id from products limit 5,1), (select id from sectors limit 5,1), 20)
  );
