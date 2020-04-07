<template>
  <div @click="setActiveKeep" class="card col-6 col-md-3">
    <router-link :to="{name: 'KeepDetails', params: {id: this.keepData.id}} ">
      <img class="card-img-top" :src="keepData.img" alt />
      <div class="card-body">
        <h4 class="card-title">{{keepData.name}}</h4>
        <p class="card-text">{{keepData.description}}</p>
      </div>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"],
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    setActiveKeep() {
      let activeKeep = {
        Id: this.keepData.id,
        UserId: this.keepData.userId,
        Name: this.keepData.name,
        Description: this.keepData.description,
        Img: this.keepData.img,
        IsPrivate: this.keepData.isPrivate,
        Views: this.keepData.views,
        Shares: this.keepData.shares,
        Keeps: this.keepData.keeps
      };
      this.$store.dispatch("setActiveKeep", activeKeep);
    }
    // addView() {
    //   this.$store.dispatch(
    //     "addView",
    //     this.activeKeep.Id,
    //     this.activeKeep.Views
    //   );
    // }
  }
};
</script>

<style scoped>
</style>