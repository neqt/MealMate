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

function Home() {
  const [data, setData] = useState([]);
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
  return (
    <div id="content" class="container-fluid">
      <div class="row">
        <div
          class="col-12 col-sm-3 col-xs-3 col-lg-2  mt-5 text-center"
          id="navLeft"
        >
          <Profile
            key={data.user_id}
            imgSrc={
              'https://i.pinimg.com/564x/f7/2d/e3/f72de35fb3f8690080cfdad5a54a0662.jpg'
            }
            name={data.user_name}
            tel={data.user_telephone}
          />
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
          <Card
            key={data.id}
            imgCilentSrc={data.imgCilentSrc}
            imgCilentSrc2={data.imgCilentSrc2}
            imgCilentSrc3={data.imgCilentSrc3}
            Header={'fsagsa'}
          />
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

export default Home;
