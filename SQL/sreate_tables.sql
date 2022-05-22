CREATE TABLE tab_roles
(
    id   INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    role TEXT NOT NULL
);

CREATE TABLE tab_accounts
(
    id       INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    login    TEXT NOT NULL,
    password TEXT NOT NULL,
    role_id  INT  NOT NULL,
    FOREIGN KEY (role_id) REFERENCES tab_roles (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_users
(
    id         INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    first_name TEXT NOT NULL,
    last_name  TEXT NOT NULL,
    FOREIGN KEY (id) REFERENCES tab_accounts (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_user_emails
(
    id      INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    user_id INT  NOT NULL,
    email   TEXT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES tab_users (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

INSERT INTO tab_roles(role)
VALUES ('guest'),
       ('user'),
       ('admin');

INSERT INTO tab_accounts(login, password, role_id)
VALUES ('_guest', '123', 1),
       ('anna', '12345', 2),
       ('ad', '123', 3);

INSERT INTO tab_users(first_name, last_name)
VALUES ('Anonim', 'Anonimus'),
       ('Anna', 'Karenina'),
       ('Admin', 'Adminus');

INSERT INTO tab_user_emails(user_id, email)
VALUES (2, 'anna@karenin.ru'),
       (3, 'admin@admin.ru'),
       (3, 'ad@admin.ru');

SELECT tab_accounts.id AS 'id', 
       login, password, role, 
       last_name, first_name, email
FROM tab_users
JOIN tab_accounts 
    ON tab_users.id = tab_accounts.id
JOIN tab_roles 
    ON tab_accounts.role_id = tab_roles.id
JOIN tab_user_emails ON tab_user_emails.user_id = tab_users.id;