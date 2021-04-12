ALTER TABLE books
    ADD COLUMN category_id bigint(20);

ALTER TABLE books
    ADD FOREIGN KEY (category_id) REFERENCES categories(id);
