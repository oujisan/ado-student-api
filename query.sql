CREATE SCHEMA users

CREATE TABLE users.students (
	student_id SERIAL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	nim VARCHAR(12) NOT NULL UNIQUE,
	prodi VARCHAR(5) NOT NULL,
	semester INT NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE,
	password VARCHAR(20) NOT NULL,
	isadmin BOOL NOT NULL
)

INSERT INTO users.students (name, nim, prodi, semester, email, password, isadmin) VALUES
	('Paman Pangeran', '232410102046', 'TI', 4, 'pamanpangeran@gmail.com', 'passwordpaman', TRUE),
	('Caniscent', '232410102070', 'TI', 4, 'caniscent@gmail.com', 'passwordcaniscent', FALSE),
	('tbqsolution', '232410102074', 'TI', 4, 'tbqsolution@gmail.com', 'passwordtbqsolution', FALSE);

SELECT * FROM users.students