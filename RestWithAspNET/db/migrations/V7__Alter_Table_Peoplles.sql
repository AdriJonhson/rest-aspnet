ALTER TABLE peoples
    ADD COLUMN enabled BOOL NOT NULL DEFAULT true AFTER gender;