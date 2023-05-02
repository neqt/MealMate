import React, { Component, useEffect, useState } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import './Home.css';
import { Link } from 'react-router-dom';
import Profile from './Profile';
import DataProfile from './DataProfile';

import Card from './Card';
import DataCard from './DataCard';

import RubSue from './RubSue';
import DataRubSue from './DataRubSue';

import FakSue from './FakSue';
import DataFakSue from './DataFakSue';
import axios from 'axios';

function App() {
  const [users, setUser, setUpdatedProfile] = useState([]);

  useEffect(async () => {
    // axios.get('https://localhost:44436/api/users').then((data) => {
    //   console.log(data);
    //   setUser(data.data?.results);
    //   debugger;
    // });
    try {
      const res = await axios({
          url: 'https://localhost:44436/api/users',
          method: 'GET',
          headers: {
          },
      })
      setUser(res.data)
      setUpdatedProfile(res.data)
  } catch (error) {
      console.log(error)
  }
  }, []);
}
export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { users: [] };
  }

  componentDidMount() {
    document.body.classList.add('HOME');
    // fetch('/api/users')
    //   .then((response) => response.json())
    //   .then((data) => {
    //     this.setState({ users: data });
    //   });
  }

  componentWillUnmount() {
    document.body.className = '';
  }

  render() {
    return (
      <div id="content" class="container-fluid">
        <div class="row">
          <div
            class="col-12 col-sm-3 col-xs-3 col-lg-2  mt-5 text-center"
            id="navLeft"
          >
            {DataProfile.map((data) => (
              <Profile
                key={data.id}
                imgSrc={data.imgSrc}
                name={data.name}
                tel={data.tel}
              />
            ))}

            <br />
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink
                  tag={Link}
                  id="HomeButton"
                  className="text-dark"
                  to="/Home"
                >
                  <h3>
                    <img
                      id="HomeIconButton"
                      src="https://sv1.picz.in.th/images/2023/04/24/y3dDQv.png"
                      alt="iconHome"
                    ></img>
                    <b>Home</b>
                  </h3>
                </NavLink>
              </NavItem>
              <NavItem>
                <div class="opacity-50">
                  <NavLink tag={Link} id="StatusButton" to="/Status">
                    <h3>
                      <img
                        id="StatusIconButton"
                        src="https://sv1.picz.in.th/images/2023/04/25/y3S5mJ.png"
                        alt="iconStatus"
                      ></img>
                      <b>Status</b>
                    </h3>
                  </NavLink>
                </div>
              </NavItem>
            </ul>
          </div>
          <div class="col-12 col-sm-6 col-lg-8 text-center" id="navCenter">
            {DataCard.map((data) => (
              <Card
                key={data.id}
                imgCilentSrc={data.imgCilentSrc}
                imgCilentSrc2={data.imgCilentSrc2}
                imgCilentSrc3={data.imgCilentSrc3}
                Header={data.Header}
              />
            ))}
          </div>

          <div class="col-12 col-sm-3 col-lg-2 text-left" id="navRight">
            <div class="px-2 pb-3 h2">
              <b>รายการรับฝาก</b>
            </div>
            <hr></hr>
            <div id="Fak">
              <div class="row p-1 mt-5 mb-4">
                <div class="col-12 h3 my-auto">รับฝาก</div>
              </div>

              {DataRubSue.slice(0, 3).map((data) => (
                <RubSue
                  key={data.id}
                  Status={data.Status}
                  Menu={data.Menu}
                  Color={data.Color}
                />
              ))}

              <div class="col-12 h6 p-2 my-auto">
                <a href="/Status" id="view">
                  <i>view all &gt;&gt;</i>
                </a>
              </div>
            </div>

            <div id="Rub">
              <div class="row p-1 mt-5 mb-4">
                <div class="col-12 h3 m-auto text-left">รอรับ</div>
              </div>

              {DataFakSue.slice(0, 3).map((data) => (
                <FakSue
                  key={data.id}
                  Status={data.Status}
                  Menu={data.Menu}
                  Color={data.Color}
                />
              ))}

              <div class="col-12 h6 p-2 my-auto">
                <a href="/Status" id="view">
                  <i>view all &gt;&gt;</i>
                </a>
              </div>
            </div>

            <div class="mx-auto text-center">
              <button class="h5 py-3 my-5" id="Get">
                ทำการสั่งอาหาร
              </button>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
