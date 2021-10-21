Create Database AddressBookDB;
Use AddressBookDB;

Create table tbl_AddressBook 
(
	Id int Primary Key Identity(1,1),
	FirstName varchar(255),
	LastName varchar(255),
	Address varchar(255) ,
	City varchar(255),
	State varchar(255),
	Zip varchar(10),
	PhoneNumber varchar(15),
	Email varchar(50), 	
);

Select * from tbl_AddressBook;

Insert into tbl_AddressBook values
('Ganesh','Gobre','Pune','Washi','Maharashtra','413503','9604877021','ganesh@gmail.com'),
('Pavan','Nakate','Solapur','Angar','Mh','112233','9625458965','pavan@gmil.com');

Create Proc SPCreateContact
(
	@FirstName varchar(255),
	@LastName varchar(255),
	@Address varchar(255) ,
	@City varchar(255),
	@State varchar(255),
	@Zip varchar(10),
	@PhoneNumber varchar(15),
	@Email varchar(50)
	
)
As
Begin
	Insert into tbl_AddressBook values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email);
End

exec SPCreateContact 'Vishal','Garad','Nagar','Pune','MH','55555','8888558522','vish@gmail.com' ;

select * from tbl_AddressBook