-- -- CREATE TABLE jobs
-- -- (
-- -- id INT NOT NULL AUTO_INCREMENT,
-- -- description VARCHAR(255),
-- -- location VARCHAR(255)NOT NULL,
-- -- contact VARCHAR(255)NOT NULL,

-- -- PRIMARY KEY (id)
-- -- );

-- SELECT * FROM contractors;

-- CREATE TABLE contractors
-- (
-- id INT NOT NULL AUTO_INCREMENT,
-- name VARCHAR(255)NOT NULL,
-- contact VARCHAR(255)NOT NULL,
-- address VARCHAR(255),
-- skills VARCHAR(255),


-- PRIMARY KEY (id)
-- );
-- DROP TABLE contractors;

-- CREATE TABLE bids
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   jobId  INT NOT NULL,
--   contractorId INT NOT NULL,
--   estimate DOUBLE NOT NULL,
-- Primary comes from the New Table Im Creating THIS IS MY NOTE
--   PRIMARY KEY (id),
--   FOREIGN KEY (jobId) REFERENCES jobs(id)
--   ON DELETE CASCADE,
--   FOREIGN KEY (contractorId) REFERENCES contractors(id)
--   ON DELETE CASCADE
--   );