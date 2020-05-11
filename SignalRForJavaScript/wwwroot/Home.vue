<template>
  <div class="home">
    <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
    <div>
      <b-button variant="outline-primary" @click="Send">Primary</b-button>
      <input v-model="Name" placeholder="Enter your Name" />
      <input v-model="Msg" placeholder="Enter your Msg" />
      <div class="row">
        <div>
          <p id="sysTitle">{{baseName}}</p>
          <ul v-for="(item, index) in messages" v-bind:key="index + 'itemMessage'">
            <li>{{item.user}}says{{item.message}}</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'
import * as signalR from "@aspnet/signalr";

export default {
  name: "Home",
  components: {
    // HelloWorld
  },
  data() {
    return {
      Name: "",
      Msg: "",
      str: "",
      connection: "",
      messages: [],
      baseInfo: Object,
      IsFirst: false,
      baseName: ""
    };
  },
  methods: {
    Send: function() {
      // this.connection.start().then(() => {
      //   this.connection
      //     .invoke("SendMessage", this.Name, this.Msg)
      //     .catch(function(err) {
      //       console.log(this.Name);
      //       console.log(this.Msg);
      //       return console.error(err);
      //     });
      // });

      this.connection
        .invoke("SendMessage", this.Name, this.Msg)
        .catch(function(err) {
          return console.error(err);
        });
    }
  },
  created: function() {
    let thisVue = this;
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5001/chathub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .configureLogging(signalR.LogLevel.Information)
      .build();
    this.connection.on("ReceiveMessage", function(user, message) {
      thisVue.messages.push({ user, message });
      // console.log({ user, message });
    });
    this.connection.start();
    this.connection.on("ReceiveLogin", function(user) {
      thisVue.baseInfo = user;
      thisVue.baseName = user.name;
      console.log(thisVue.baseInfo);
    });
  },
  mounted: function() {
    // this.connection.on("ReceiveUpdate", function(user) {
    //   this.baseInfo = user;
    //   this.IsFirst = true;
    // });
    // let thisVue = this;
    // let name = thisVue.baseInfo.name;
    // console.log("名称" + name);
    // console.log(thisVue.baseInfo);
    // setTimeout(() => {
    //   thisVue.baseName = name;
    // }, 5000);
  }
};
</script>
<style lang="scss" scoped>
p {
  margin-left: 200px;
}
</style>

