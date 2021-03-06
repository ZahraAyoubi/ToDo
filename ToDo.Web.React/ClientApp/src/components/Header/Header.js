//import useState hook to create menu collapse state
import React, { useState } from "react";
import { Link } from 'react-router-dom';

//import react pro sidebar components
import {
    ProSidebar,
    Menu,
    MenuItem,
    SidebarHeader,
    SidebarFooter,
    SidebarContent,
} from "react-pro-sidebar";

//import icons from react icons
import { FaCalendarCheck, FaChild, FaList, FaPizzaSlice, FaPlus, FaSun, FaTripadvisor } from "react-icons/fa";
import { FiHome, FiLogOut, FiArrowLeftCircle, FiArrowRightCircle } from "react-icons/fi";

//import sidebar css from react-pro-sidebar module and our custom css 
import "react-pro-sidebar/dist/css/styles.css";
import "./Header.css";


const Header = () => {

    //create initial menuCollapse state using useState hook
    const [menuCollapse, setMenuCollapse] = useState(false)

    //create a custom function that will change menucollapse state from false to true and true to false
    const menuIconClick = () => {
        //condition checking to change state from true to false and vice versa
        menuCollapse ? setMenuCollapse(false) : setMenuCollapse(true);
    };

    return (
        <>
            <div id="header">
                {/* collapsed props to change menu size using menucollapse state */}
                <ProSidebar collapsed={menuCollapse}>
                    <SidebarHeader>
                        <div className="logotext">
                        </div>
                        <div className="closemenu" onClick={menuIconClick}>
                            {/* changing menu collapse icon on click */}
                            {menuCollapse ? (
                                <FiArrowRightCircle />
                            ) : (
                                <FiArrowLeftCircle />
                            )}
                        </div>
                    </SidebarHeader>
                    <SidebarContent>
                        <Menu iconShape="square">
                            <MenuItem icon={<FiHome />} >Home
                                <Link to ="/home"/>
                            </MenuItem>
                            <MenuItem icon={<FaSun />}>My day
                                <Link to="/myday" />
                            </MenuItem>
                            <MenuItem icon={<FaCalendarCheck />}>ToDo
                                <Link to="/todo" />
                            </MenuItem>
                            <MenuItem icon={<FaPizzaSlice />}>Geroceries
                                <Link to="/geroceries" />
                            </MenuItem>
                            <MenuItem icon={<FaList />}>Work
                                <Link to="/work" />
                            </MenuItem>
                            <MenuItem icon={<FaChild />}>Family
                                <Link to="/family" />
                            </MenuItem>
                            <MenuItem icon={<FaTripadvisor />}>Travel
                                <Link to="/travel" />
                            </MenuItem>
                            <MenuItem icon={<FaPlus />}>New list
                                <Link to="/newlist" />
                            </MenuItem>
                        </Menu>
                        </SidebarContent>
                    <SidebarFooter>
                        <Menu iconShape="square">
                            <MenuItem icon={<FiLogOut />}>Logout</MenuItem>
                        </Menu>
                    </SidebarFooter>
                </ProSidebar>
            </div>
        </>
    );
};

export default Header;