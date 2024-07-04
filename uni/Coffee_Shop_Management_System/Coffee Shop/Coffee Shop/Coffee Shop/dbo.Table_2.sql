CREATE TABLE Orders (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ItemName NVARCHAR(50),
    UnitPrice DECIMAL(18, 2),
    Quantity INT,
    Total DECIMAL(18, 2),
    DateTime DATETIME
);
