import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from 'reactstrap';
import './Login.css';
import axios from 'axios';

function SignUp() {
  useEffect(() => {
    componentDidMount();
  }, []);

  function componentDidMount() {
    axios
      .get('https://localhost:7296/api/Users/6')
      .then(function (response) {
        console.log(response.data);
        setData(response.data);
      })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
      .finally(function () {
        // always executed
      });
  }
  // export class SignUp extends Component {
  //   static displayName = SignUp.name;

  //   componentDidMount() {
  //     document.body.classList.add('LOGIN');
  // }

  // componentWillUnmount() {
  //     document.body.className = '';
  //   }

  // render() {
  return (
    <div>
      <Navbar
        className="navbar-expand-sm fixed-top navbar-toggleable-sm bg-white border-bottom box-shadow mb-3"
        container-fuild
        light
      >
        <NavbarBrand tag={Link} to="/Login">
          <img
            src="https://sv1.picz.in.th/images/2023/04/08/mlIkAa.png"
            alt="logo.png"
            border="0"
            width="100px"
          />
        </NavbarBrand>
        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
      </Navbar>

      <div style={{ marginTop: '8%' }} className="image-container">
        <h2 style={{ fontWeight: 'bold', transform: 'translateY(65px)' }}>
          Create Account
        </h2>
      </div>
      <div className="wrapper-signup">
        <form>
          <label>USERNAME</label>
          <input type="email" placeholder="" />
          <label>PASSWORD</label>
          <input type="password" placeholder="" />
          <label>TEL NUMBER</label>
          <input type="tel number" placeholder="" />
        </form>
        <button class="CREATE">Create Account</button>
        <div className="not-member">
          Already have an account? <Link to="/login">Sign in</Link>
        </div>
      </div>
    </div>
  );
}

export default SignUp;
