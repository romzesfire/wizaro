﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE personal_data (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    first_name integer NOT NULL,
    second_name integer NOT NULL,
    third_name integer NULL,
    date_of_birth timestamp with time zone NULL,
    CONSTRAINT "PK_personal_data" PRIMARY KEY (id)
);

CREATE TABLE price (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    main_price numeric NOT NULL,
    sale_price numeric NOT NULL,
    CONSTRAINT "PK_price" PRIMARY KEY (id)
);

CREATE TABLE role (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    role_name integer NOT NULL,
    CONSTRAINT "PK_role" PRIMARY KEY (id)
);

CREATE TABLE product (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    name text NOT NULL,
    description text NOT NULL,
    image_sources text[] NOT NULL,
    price_id integer NOT NULL,
    time_to_complete integer NULL,
    product_type integer NOT NULL,
    CONSTRAINT "PK_product" PRIMARY KEY (id),
    CONSTRAINT "FK_product_price_price_id" FOREIGN KEY (price_id) REFERENCES price (id) ON DELETE CASCADE
);

CREATE TABLE cart (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    user_id integer NOT NULL,
    CONSTRAINT "PK_cart" PRIMARY KEY (id)
);

CREATE TABLE users (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    login text NOT NULL,
    password_hash text NOT NULL,
    email text NOT NULL,
    personal_data_id integer NOT NULL,
    role_id integer NOT NULL,
    cart_id integer NOT NULL,
    CONSTRAINT "PK_users" PRIMARY KEY (id),
    CONSTRAINT "FK_users_cart_cart_id" FOREIGN KEY (cart_id) REFERENCES cart (id) ON DELETE CASCADE,
    CONSTRAINT "FK_users_personal_data_personal_data_id" FOREIGN KEY (personal_data_id) REFERENCES personal_data (id) ON DELETE CASCADE,
    CONSTRAINT "FK_users_role_role_id" FOREIGN KEY (role_id) REFERENCES role (id) ON DELETE CASCADE
);

CREATE TABLE "order" (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    product_id integer NOT NULL,
    count integer NOT NULL,
    "UserId" integer NULL,
    CONSTRAINT "PK_order" PRIMARY KEY (id),
    CONSTRAINT "FK_order_product_product_id" FOREIGN KEY (product_id) REFERENCES product (id) ON DELETE CASCADE,
    CONSTRAINT "FK_order_users_UserId" FOREIGN KEY ("UserId") REFERENCES users (id)
);

CREATE TABLE counted_product (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    product_id integer NOT NULL,
    count integer NOT NULL,
    cart_id integer NULL,
    order_id integer NULL,
    CONSTRAINT "PK_counted_product" PRIMARY KEY (id),
    CONSTRAINT "FK_counted_product_cart_cart_id" FOREIGN KEY (cart_id) REFERENCES cart (id),
    CONSTRAINT "FK_counted_product_order_order_id" FOREIGN KEY (order_id) REFERENCES "order" (id),
    CONSTRAINT "FK_counted_product_product_product_id" FOREIGN KEY (product_id) REFERENCES product (id) ON DELETE CASCADE
);

CREATE INDEX "IX_cart_user_id" ON cart (user_id);

CREATE INDEX "IX_counted_product_cart_id" ON counted_product (cart_id);

CREATE INDEX "IX_counted_product_order_id" ON counted_product (order_id);

CREATE INDEX "IX_counted_product_product_id" ON counted_product (product_id);

CREATE INDEX "IX_order_product_id" ON "order" (product_id);

CREATE INDEX "IX_order_UserId" ON "order" ("UserId");

CREATE INDEX "IX_product_price_id" ON product (price_id);

CREATE INDEX "IX_users_cart_id" ON users (cart_id);

CREATE INDEX "IX_users_personal_data_id" ON users (personal_data_id);

CREATE INDEX "IX_users_role_id" ON users (role_id);

ALTER TABLE cart ADD CONSTRAINT "FK_cart_users_user_id" FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240517113953_Initial', '7.0.10');

COMMIT;

