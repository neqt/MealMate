import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import './Login.css';

export class SignUp extends Component {
  static displayName = SignUp.name;

  componentDidMount() {
    document.body.classList.add('LOGIN');
}

componentWillUnmount() {
    document.body.className = '';
  }

  render() {
    return (
      <div>
        <Navbar className="navbar-expand-sm fixed-top navbar-toggleable-sm bg-white border-bottom box-shadow mb-3" container-fuild light>
        <NavbarBrand tag={Link} to="/Login"><img src="https://sv1.picz.in.th/images/2023/04/08/mlIkAa.png" alt="logo.png" border="0"
                        width="100px" /></NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
        </Navbar>

        <div style={{marginTop: "8%"}} className="image-container">
        <h2 style={{fontWeight: "bold", transform: "translateY(65px)"}}>Create Account</h2>
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
          <button class= "CREATE">Create Account</button>
          <div className="not-member">
            Already have an account? <Link to="/login">Sign in</Link>
          </div>
        </div>
      </div>
    );
  }
}



// import React, { useState } from "react";
// import axios from "axios";

// export function SignUp() {
//   const [user, setUser] = useState({
//     user_name: "",
//     user_password: "",
//     user_telephone: "",
//   });

//   function handleChange(event) {
//     const { name, value } = event.target;
//     setUser((prevUser) => ({
//       ...prevUser,
//       [name]: value,
//     }));
//   }

//   function handleSubmit(event) {
//     event.preventDefault();
//     axios.post("/User/regis", user).then((response) => {
//       console.log(response);
//       // do something after submitting the form
//     });
//   }

//   return (
//     <div className="row">
//       <div className="col-md-4">
//         <form onSubmit={handleSubmit}>
//           <div className="form-group">
//             <label htmlFor="user_name">User Name</label>
//             <input
//               type="text"
//               className="form-control"
//               id="user_name"
//               name="user_name"
//               value={user.user_name}
//               onChange={handleChange}
//             />
//           </div>
//           <div className="form-group">
//             <label htmlFor="user_password">User Password</label>
//             <input
//               type="password"
//               className="form-control"
//               id="user_password"
//               name="user_password"
//               value={user.user_password}
//               onChange={handleChange}
//             />
//           </div>
//           <div className="form-group">
//             <label htmlFor="user_telephone">User Telephone</label>
//             <input
//               type="text"
//               className="form-control"
//               id="user_telephone"
//               name="user_telephone"
//               value={user.user_telephone}
//               onChange={handleChange}
//             />
//           </div>
//           <button type="submit" className="btn btn-primary">
//             Create
//           </button>
//         </form>
//       </div>
//     </div>
//   );
// }