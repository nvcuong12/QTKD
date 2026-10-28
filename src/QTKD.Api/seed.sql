INSERT INTO "Customers" ("Name", "Status") VALUES
('Công ty Minh Phát', 'Active'),
('Công ty An Khang', 'Active');

INSERT INTO "PriceLists" ("Name", "EffectiveDate") VALUES
('Bảng giá dịch vụ 2026', '2026-01-01');

INSERT INTO "Contracts" ("ContractNo", "CustomerId", "StartDate", "EndDate", "Status")
VALUES (
  'HD-2026-018',
  (SELECT "Id" FROM "Customers" WHERE "Name" = 'Công ty Minh Phát'),
  '2026-01-01',
  '2026-12-31',
  'Draft'
);

INSERT INTO "PriceItems" ("PriceListId", "ServiceCode", "UnitPrice") VALUES
((SELECT "Id" FROM "PriceLists" WHERE "Name" = 'Bảng giá dịch vụ 2026'), 'SVC-LOG-01', 1500000),
((SELECT "Id" FROM "PriceLists" WHERE "Name" = 'Bảng giá dịch vụ 2026'), 'SVC-LOG-02', 2200000);