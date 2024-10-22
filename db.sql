create table clients
(
    client_id varchar(10) primary key,
    name      varchar(100) not null,
    email     varchar(100) not null,
    address   varchar(100) not null
);


create table invoices(
    invoice_number varchar(40) primary key ,
    client_id varchar(10) not null,
    due_date timestamptz not null,
    status varchar(10) not null
);

create table invoice_items(
    id serial primary key ,
    invoice_number varchar(40) not null,
    quantity int not null,
    price decimal not null,
    description varchar(255)
);

INSERT INTO clients (client_id, name, email, address) VALUES ('C001', 'Acme Corp', 'info@acmecorp.com', '123 Industrial Road, Springfield');
INSERT INTO clients (client_id, name, email, address) VALUES ('C002', 'Globex Corporation', 'contact@globex.com', '45 Elm Street, Capital City');
INSERT INTO clients (client_id, name, email, address) VALUES ('C003', 'Soylent Corp', 'hello@soylent.com', '67 Green Avenue, Metropolis');
INSERT INTO clients (client_id, name, email, address) VALUES ('C004', 'Initech', 'support@initech.com', '99 Startup Lane, Silicon Valley');
INSERT INTO clients (client_id, name, email, address) VALUES ('C005', 'Umbrella Corporation', 'admin@umbrella.com', '100 Biohazard Blvd, Racoon City');
INSERT INTO clients (client_id, name, email, address) VALUES ('C006', 'Stark Industries', 'tech@starkindustries.com', '200 Iron Avenue, Malibu');
INSERT INTO clients (client_id, name, email, address) VALUES ('C007', 'Wayne Enterprises', 'info@wayneenterprises.com', '1 Gotham Plaza, Gotham');
INSERT INTO clients (client_id, name, email, address) VALUES ('C008', 'Tyrell Corporation', 'replicants@tyrell.com', '700 Future Street, Los Angeles');
INSERT INTO clients (client_id, name, email, address) VALUES ('C009', 'Cyberdyne Systems', 'tech@cyberdyne.com', '550 AI Drive, San Francisco');

INSERT INTO invoices (invoice_number, client_id, due_date, status) VALUES
('INV-1001', 'C001', '2023-09-30', 'Pending'),
('INV-1002', 'C002', '2023-09-25', 'Paid'),
('INV-1003', 'C002', '2023-10-05', 'Overdue'),
('INV-1004', 'C002', '2023-10-10', 'Pending'),
('INV-1005', 'C003', '2023-09-20', 'Paid'),
('INV-1006', 'C003', '2023-10-15', 'Pending'),
('INV-1007', 'C004', '2023-09-29', 'Overdue'),
('INV-1008', 'C005', '2023-09-27', 'Paid'),
('INV-1009', 'C005', '2023-09-26', 'Pending'),
('INV-1010', 'C006', '2023-10-01', 'Overdue'),
('INV-1011', 'C006', '2023-09-21', 'Paid'),
('INV-1012', 'C002', '2023-09-30', 'Pending'),
('INV-1013', 'C003', '2023-10-05', 'Overdue'),
('INV-1014', 'C004', '2023-09-23', 'Paid'),
('INV-1015', 'C005', '2023-09-28', 'Pending'),
('INV-1016', 'C006', '2023-10-07', 'Pending'),
('INV-1017', 'C007', '2023-09-22', 'Paid'),
('INV-1018', 'C008', '2023-10-02', 'Overdue'),
('INV-1019', 'C009', '2023-09-24', 'Paid'),
('INV-1020', 'C001', '2023-09-30', 'Pending');

INSERT INTO invoice_items (invoice_number, quantity, price, description) VALUES
('INV-1001', 10, 300, 'Web Design Services'),
('INV-1001', 5, 200, 'SEO Optimization'),
('INV-1002', 5, 500, 'Consulting Services'),
('INV-1003', 3, 500, 'Marketing Campaign'),
('INV-1004', 20, 200, 'Software Development'),
('INV-1005', 8, 400, 'Product Design'),
('INV-1006', 5, 550, 'Tech Consultation'),
('INV-1007', 10, 430, 'Business Analysis'),
('INV-1008', 4, 475, 'Database Migration'),
('INV-1009', 30, 200, 'AI Development'),
('INV-1010', 11, 300, 'Product Research'),
('INV-1011', 5, 550, 'Energy Consulting'),
('INV-1012', 10, 415, 'Time Machine Repair'),
('INV-1013', 6, 500, 'Marketing Campaign'),
('INV-1014', 4, 550, 'Construction Services'),
('INV-1015', 3, 550, 'Import/Export Consulting'),
('INV-1016', 5, 500, 'Content Creation'),
('INV-1017', 8, 600, 'E-commerce Setup'),
('INV-1018', 4, 450, 'Social Media Strategy'),
('INV-1019', 5, 750, 'IT Infrastructure'),
('INV-1020', 7, 435, 'Financial Consulting');

