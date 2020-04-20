<template>
  <div class="home container-fluid">
    <h1 class="text-center">HOME</h1>

    <form class="text-center" @submit.prevent="addKeep">
      <h3 class="text-center">Make a new Keep</h3>
      <div style="list-style-type:none">
        <input type="text" placeholder="title" v-model="newKeep.Name" required />
        <br />
        <input type="text" placeholder="description" v-model="newKeep.Description" />
        <br />
        <input type="text" placeholder="img URL" v-model="newKeep.Img" />
        <br />
        <h6>Mark as Private?</h6>
        <input type="checkbox" id="checkbox" v-model="newKeep.isPrivate" />
      </div>
      <button type="submit" title="Make new Keep" class="btn btn-primary btn-lg">+</button>
    </form>

    <div class="row">
      <Keep v-for="Keep in publicKeeps" :key="Keep.id" :keepData="Keep" />
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep";
export default {
  name: "home",
  mounted() {
    return this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  components: {
    Keep
  },
  data() {
    return {
      newKeep: {
        Name: "",
        Description: "",
        Img: "",
        isPrivate: false
      }
    };
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
    },
    setActiveKeep() {
      this.$store.dispatch("setActiveKeep");
    }
  }
};
</script>
<style scoped>
* {
  max-width: 100vw;
}
</style>
