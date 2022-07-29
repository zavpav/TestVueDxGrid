<template>
  <!-- <img alt="Vue logo" src="./assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" /> 
  -->
  <DxButton text="Click me" @click="sayHello" />
  <TestComponent />
  <TestGrid />
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import HelloWorld from "./components/HelloWorld.vue";
import TestComponent from "./components/TestComponent.vue";
import TestGrid from "./components/TestGrid.vue";

import DxButton from "devextreme-vue/button";

@Options({
  components: {
    HelloWorld,
    DxButton,
    TestComponent,
    TestGrid,
  },
})
export default class App extends Vue {
  sayHello() {
    alert(1);
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
