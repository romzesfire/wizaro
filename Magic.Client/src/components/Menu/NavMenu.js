import React, {useState} from 'react';
import '../Styles/NavMenu.css'
import {
    Collapse,
    Navbar,
    NavbarToggler,
    NavbarBrand,
    Nav,
    NavItem,
    NavLink,
    UncontrolledDropdown,
    DropdownToggle,
    DropdownMenu,
    DropdownItem,
    NavbarText,
} from 'reactstrap';

export default function NavMenu(args) {
    const [isOpen, setIsOpen] = useState(false);

    const toggle = () => setIsOpen(!isOpen);

    return (
        <div>
            <Navbar style={{boxShadow: '0 1px 4px 1px black'}} color='dark' dark={true} expand='md' container='fluid'>
                <NavbarBrand href="/">Визаро</NavbarBrand>
                <NavbarToggler onClick={toggle}/>
                <Collapse isOpen={isOpen} navbar>
                    <Nav fill className="me-auto" navbar>
                        <NavItem>
                            <NavLink href="/components/">
                                Home
                            </NavLink>
                        </NavItem>
                        <UncontrolledDropdown nav inNavbar>
                            <DropdownToggle nav caret>
                                Товары и услуги
                            </DropdownToggle>
                            <DropdownMenu center>
                                <DropdownItem href={"/tags/operations"}>Товары</DropdownItem>
                                <DropdownItem href={"/tags/assign"}>Услуги</DropdownItem>
                            </DropdownMenu>
                        </UncontrolledDropdown>
                        <NavItem>
                            <NavLink href="/components/">
                                О нас
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink href="/components/">
                                Контакты
                            </NavLink>
                        </NavItem>
                    </Nav>
                </Collapse>
            </Navbar>
        </div>
    );
}